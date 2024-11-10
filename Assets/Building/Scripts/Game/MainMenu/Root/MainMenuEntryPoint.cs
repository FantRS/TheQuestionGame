using BaCon;
using MainSpace.Configs;
using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Presenters;
using MainSpace.Root;
using UnityEngine;

namespace MainSpace.MainMenu.Root
{
    public sealed class MainMenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private ViewStorage _mainMenuUIPrefab;
        [SerializeField] private QuestionVaultConfig _questionVaultConfig;

        public void Run(DIContainer sceneContainer)
        {
            // resolving intances
            var rootUI = sceneContainer.Resolve<RootUIView>();

            // attaching UI
            var viewStorage = Instantiate(_mainMenuUIPrefab);
            rootUI.AttachSceneUI(viewStorage.gameObject);

            // registration instances
            sceneContainer.RegisterInstance(_questionVaultConfig);
            sceneContainer.RegisterInstance(viewStorage);

            // creating presenters
            var mainMenuPresenter = 
                new MainMenuPresenter(viewStorage.MainMenuView, new MainMenuModel(sceneContainer));
        }
    }
}
