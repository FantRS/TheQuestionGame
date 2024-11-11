using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Views;

namespace MainSpace.MainMenu.Presenters
{
    public sealed class MainMenuPresenter
    {
        private readonly MainMenuView _mainMenuView;
        private readonly MainMenuModel _mainMenuModel;

        private ScreenPresenter _cachedPresenter;

        public MainMenuPresenter(MainMenuView view, MainMenuModel model)
        {
            _mainMenuView = view;
            _mainMenuModel = model;

            EventSubsctiptions();
        }

        private void EventSubsctiptions()
        {
            _mainMenuView.OnForGirlsQuestionsButtonClickEvent += () =>
            {
                _mainMenuView.OpenGirlsQuestionsScreen();

                CreateNewPresenter(_mainMenuModel.ViewStorage.ForGirlsScreen,
                    new ScreenModel(_mainMenuModel.QuestionsConfig.ForGirlsQuestionConfig));
            };

            _mainMenuView.OnForBoysQuestionsButtonClickEvent += () =>
            {
                _mainMenuView.OpenBoysQuestionsScreen();

                CreateNewPresenter(_mainMenuModel.ViewStorage.ForBoysScreen,
                    new ScreenModel(_mainMenuModel.QuestionsConfig.ForBoysQuestionConfig));
            };

            _mainMenuView.OnForLoversQuestionsButtonClickEvent += () =>
            {
                _mainMenuView.OpenLoversQuestionsScreen();

                CreateNewPresenter(_mainMenuModel.ViewStorage.ForLoverScreen,
                    new ScreenModel(_mainMenuModel.QuestionsConfig.ForLoversQuestionConfig));
            };

            _mainMenuView.OnFunnyQuestionsButtonClickEvent += () =>
            {
                _mainMenuView.OpenFunnyQuestionsScreen();

                CreateNewPresenter(_mainMenuModel.ViewStorage.FunnyScreen,
                    new ScreenModel(_mainMenuModel.QuestionsConfig.FunnyQuestionConfig));
            };

            _mainMenuView.OnArtistQuestionsButtonClickEvent += () =>
            {
                _mainMenuView.OpenArtistQuestionsScreen();

                CreateNewPresenter(_mainMenuModel.ViewStorage.ArtistsScreen,
                    new ScreenModel(_mainMenuModel.QuestionsConfig.ArtistsQuestionConfig));
            };

            _mainMenuView.OnLifeQuestionsButtonClickEvent += () =>
            {
                _mainMenuView.OpenLifeQuestionsScreen();

                CreateNewPresenter(_mainMenuModel.ViewStorage.LifeScreen,
                    new ScreenModel(_mainMenuModel.QuestionsConfig.LifeQuestionConfig));
            };

            _mainMenuView.OnDreamQuestionsButtonClickEvent += () =>
            {
                _mainMenuView.OpenDreamQuestionsScreen();

                CreateNewPresenter(_mainMenuModel.ViewStorage.DreamScreen,
                    new ScreenModel(_mainMenuModel.QuestionsConfig.DreamsQuestionConfig));
            };

            _mainMenuView.OnChurchQuestionsButtonClickEvent += () =>
            {
                _mainMenuView.OpenChurchQuestionsScreen();

                CreateNewPresenter(_mainMenuModel.ViewStorage.ChurchScreen,
                    new ScreenModel(_mainMenuModel.QuestionsConfig.ChurchQuestionConfig));
            };
        }

        private void CreateNewPresenter(ScreenView view, ScreenModel model)
        {
            _cachedPresenter?.Dispose();
            _cachedPresenter = new ScreenPresenter(view, model);
        }
    }
}
