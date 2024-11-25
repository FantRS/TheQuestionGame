using BaCon;
using MainSpace.Configs;
using MainSpace.Data.Root;
using MainSpace.MainMenu.Root;
using MainSpace.ScreenScene.Root;
using MainSpace.Utils;
using R3;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainSpace.Root
{
    public sealed class GameEntryPoint
    {
        private static GameEntryPoint _instance;

        private readonly RootUIView _rootUI;
        private readonly DIContainer _rootContainer;
        private readonly Coroutines _coroutines;
        private readonly GameManager _gameManager;
        private DIContainer _cachedSceneContainer;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutostartGame()
        {
            _instance = new GameEntryPoint();
            _instance.RunGame();
        }

        private GameEntryPoint()
        {
            // creating coroutines
            _coroutines = new GameObject("Coroutines").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(_coroutines);

            // loading RootUI from resources
            var rootUIResources = Resources.Load<RootUIView>("RootUI");
            _rootUI = Object.Instantiate(rootUIResources);
            Object.DontDestroyOnLoad(_rootUI.gameObject);

            // loading datas
            var dataProvider = new DataProvider();
            dataProvider.LoadFavouriteQuestionData();

            // creating game manager
            _gameManager = new GameObject("GameManager").AddComponent<GameManager>();
            Object.DontDestroyOnLoad(_gameManager);
            _gameManager.SetDataProvider(dataProvider);

            // creating DIContainer and register instances
            _rootContainer = new DIContainer();
            _rootContainer.RegisterInstance(_rootUI);
            _rootContainer.RegisterInstance(dataProvider);
        }

        private void RunGame()
        {
            UnityEngine.Device.Application.targetFrameRate = 
                (int)UnityEngine.Device.Screen.currentResolution.refreshRateRatio.value;

            _coroutines.StartCoroutine(LoadMenuScene());
        }

        private IEnumerator LoadMenuScene()
        {
            _rootUI.ShowLoadingScreen();

            _cachedSceneContainer?.Dispose();

            yield return LoadScene(Scenes.BOOT);
            yield return LoadScene(Scenes.MAIN_MENU);
            yield return new WaitForSeconds(1f);

            var mainMenuEntryPoint = Object.FindAnyObjectByType<MainMenuEntryPoint>();
            var sceneContainer = _cachedSceneContainer = new DIContainer(_rootContainer);

            mainMenuEntryPoint.Run(sceneContainer)
                .Subscribe(config => _coroutines.StartCoroutine(LoadScreenScene(config)));

            _rootUI.HideLoadingScreen();
        }

        private IEnumerator LoadScreenScene(ScreenConfig screenConfig)
        {
            _rootUI.ShowLoadingScreen();

            _cachedSceneContainer?.Dispose();

            yield return LoadScene(Scenes.BOOT);
            yield return LoadScene(Scenes.SCREEN);
            yield return new WaitForSeconds(1f);

            var screenEntryPoint = Object.FindAnyObjectByType<ScreenEntryPoint>();
            var sceneContainer = _cachedSceneContainer = new DIContainer(_rootContainer);
            sceneContainer.RegisterInstance(screenConfig);

            screenEntryPoint.Run(sceneContainer)
                .Subscribe(_ => _coroutines.StartCoroutine(LoadMenuScene()));

            _rootUI.HideLoadingScreen();
        }

        private IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}