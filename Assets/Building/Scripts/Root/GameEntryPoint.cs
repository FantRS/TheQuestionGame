using BaCon;
using MainSpace.MainMenu.Root;
using MainSpace.Utils;
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

            // creating DIContainer and register instances
            _rootContainer = new DIContainer();
            _rootContainer.RegisterInstance(_rootUI);
        }

        private void RunGame()
        {
            _coroutines.StartCoroutine(LoadMenuScene());
        }

        private IEnumerator LoadGameplayScene()
        {
            yield return null;
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
            mainMenuEntryPoint.Run(sceneContainer);

            _rootUI.HideLoadingScreen();
        }

        private IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}