using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Views;

namespace MainSpace.MainMenu.Presenters
{
    public sealed class MainMenuPresenter
    {
        private readonly MainMenuView _mainMenuView;
        private readonly MainMenuModel _mainMenuModel;

        public MainMenuPresenter(MainMenuView view, MainMenuModel model)
        {
            _mainMenuView = view;
            _mainMenuModel = model;

            ReactiveSubscription();
            EventSubsctiption();
        }

        private void EventSubsctiption()
        {
            _mainMenuView.OnForGirlsQuestionsButtonClickEvent += () =>
            {
                _mainMenuView.OpenGirlsQuestionsScreen();

                var screenPresenter = new ScreenPresenter(_mainMenuModel.ViewStorage.ForGirlsScreen, 
                    new ScreenModel(_mainMenuModel.QuestionsConfig.ForGirlsQuestionConfig));
            };

            _mainMenuView.OnForBoysQuestionsButtonClickEvent += () =>
            {
                _mainMenuView.OpenBoysQuestionsScreen();

                var screenPresenter = new ScreenPresenter(_mainMenuModel.ViewStorage.ForBoysScreen,
                    new ScreenModel(_mainMenuModel.QuestionsConfig.ForBoysQuestionConfig));
            };
        }

        private void ReactiveSubscription() { }
    }
}
