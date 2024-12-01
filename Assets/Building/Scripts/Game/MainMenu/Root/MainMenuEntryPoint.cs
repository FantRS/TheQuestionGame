using BaCon;
using MainSpace.Configs;
using MainSpace.Data.Root;
using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Presenters;
using MainSpace.Root;
using R3;
using UnityEngine;

namespace MainSpace.MainMenu.Root
{
    public sealed class MainMenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private MainMenuViewStorage _mainMenuViewStoragePrefab;
        [SerializeField] private ScreenVaultConfig _questionVaultConfig;

        public Observable<ScreenConfig> Run(DIContainer sceneContainer)
        {
            // resolving intances
            var rootUI = sceneContainer.Resolve<RootUIView>();
            var dataProvider = sceneContainer.Resolve<DataProvider>();

            // registrated instances
            sceneContainer.RegisterInstance(_questionVaultConfig);

            // attaching UI
            var mainMenuViewStorage = Instantiate(_mainMenuViewStoragePrefab);
            rootUI.AttachSceneUI(mainMenuViewStorage.gameObject);

            // getting views from view storage
            var mainMenuView = mainMenuViewStorage.MainMenuView;
            var settingsView = mainMenuViewStorage.SettingsView;

            // creating presenters
            var mainMenuModel = new MainMenuModel(sceneContainer);

            var mainMenuPresenter = new MainMenuPresenter(mainMenuView, mainMenuModel);
            //var settingsPresenter = new SettingsPresenter(settingsView, mainMenuModel);

            // binding transition signal
            var sceneTransitionSignal = new Subject<ScreenConfig>();
            mainMenuView.BindSceneTransitionSignal(sceneTransitionSignal);
            return sceneTransitionSignal;
        }
    }
}
