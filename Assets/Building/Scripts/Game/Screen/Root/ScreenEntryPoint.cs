using BaCon;
using MainSpace.Configs;
using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Presenters;
using MainSpace.MainMenu.Views;
using MainSpace.Root;
using R3;
using UnityEngine;

namespace MainSpace.Screen.Root
{
    public sealed class ScreenEntryPoint : MonoBehaviour
    {
        [SerializeField] private ScreenView _screenViewUiPrefab;

        public Observable<Unit> Run(DIContainer sceneContainer)
        {
            // resolving instances
            var rootUI = sceneContainer.Resolve<RootUIView>();
            var config = sceneContainer.Resolve<ScreenConfig>();

            // attaching UI
            var screenView = Instantiate(_screenViewUiPrefab);
            rootUI.AttachSceneUI(screenView.gameObject);

            // registration instances

            // binding transition signal
            var sceneTransitionSignal = new Subject<Unit>();
            screenView.BindSceneTransitionSignal(sceneTransitionSignal);

            // creation presenters
            var screenPresenter =
                new ScreenPresenter(screenView, new ScreenModel(config));

            return sceneTransitionSignal;
        }
    }
}
