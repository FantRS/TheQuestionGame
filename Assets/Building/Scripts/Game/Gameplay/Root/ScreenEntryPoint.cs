using BaCon;
using MainSpace.Configs;
using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Presenters;
using MainSpace.MainMenu.Root;
using MainSpace.Root;
using R3;
using UnityEngine;

namespace MainSpace.ScreenScene.Root
{
    public sealed class ScreenEntryPoint : MonoBehaviour
    {
        [SerializeField] private ScreenViewStorage _viewStorageUiPrefab;

        public Observable<Unit> Run(DIContainer sceneContainer)
        {
            // resolving instances
            var rootUI = sceneContainer.Resolve<RootUIView>();
            var config = sceneContainer.Resolve<ScreenConfig>();

            //// registration instances
            //sceneContainer.RegisterInstance(config);

            // attaching UI
            var viewStorage = Instantiate(_viewStorageUiPrefab);
            rootUI.AttachSceneUI(viewStorage.gameObject);

            // getting views from view storage
            var screenView = viewStorage.ScreenView;
            var questionListView = viewStorage.QuestionListView;

            // binding transition signal
            var sceneTransitionSignal = new Subject<Unit>();
            screenView.BindSceneTransitionSignal(sceneTransitionSignal);

            // creation presenters
            var screenModel = new ScreenModel(sceneContainer);

            var screenPresenter = new ScreenPresenter(screenView, screenModel);
            var questionListPresenter = new QuestionListPresenter(questionListView, screenModel);

            return sceneTransitionSignal;
        }
    }
}
