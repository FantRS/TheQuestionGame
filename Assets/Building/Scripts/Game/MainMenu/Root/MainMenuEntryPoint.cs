using BaCon;
using MainSpace.Configs;
using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Presenters;
using MainSpace.MainMenu.Views;
using MainSpace.Root;
using UnityEngine;
using R3;

namespace MainSpace.MainMenu.Root
{
    public sealed class MainMenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private MainMenuView _mainMenuUIPrefab;
        [SerializeField] private ScreenVaultConfig _questionVaultConfig;

        public Observable<ScreenConfig> Run(DIContainer sceneContainer)
        {
            // resolving intances
            var rootUI = sceneContainer.Resolve<RootUIView>();

            // attaching UI
            var mainMenuView = Instantiate(_mainMenuUIPrefab);
            rootUI.AttachSceneUI(mainMenuView.gameObject);

            // binding transition signal
            var sceneTransitionSignal = new Subject<ScreenConfig>();
            mainMenuView.BindSceneTransitionSignal(sceneTransitionSignal);

            // creating presenters
            var mainMenuPresenter = 
                new MainMenuPresenter(mainMenuView, new MainMenuModel(_questionVaultConfig));

            return sceneTransitionSignal;
        }
    }
}
