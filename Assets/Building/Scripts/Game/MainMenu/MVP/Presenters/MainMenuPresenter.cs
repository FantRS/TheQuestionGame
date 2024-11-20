using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Views;
using R3;

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

            EventSubsctiptions();
            UpdateQuestionsCount();
        }

        private void EventSubsctiptions()
        {
            _mainMenuView.OnForGirlsQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _mainMenuView.SceneTransitionSignal
                    .OnNext(_mainMenuModel.QuestionsConfig.ForGirlsQuestionConfig);
            });

            _mainMenuView.OnForBoysQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _mainMenuView.SceneTransitionSignal
                    .OnNext(_mainMenuModel.QuestionsConfig.ForBoysQuestionConfig);
            });

            _mainMenuView.OnForLoversQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _mainMenuView.SceneTransitionSignal
                    .OnNext(_mainMenuModel.QuestionsConfig.ForLoversQuestionConfig);
            });

            _mainMenuView.OnFunnyQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _mainMenuView.SceneTransitionSignal
                    .OnNext(_mainMenuModel.QuestionsConfig.FunnyQuestionConfig);
            });

            _mainMenuView.OnArtistQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _mainMenuView.SceneTransitionSignal
                    .OnNext(_mainMenuModel.QuestionsConfig.ArtistsQuestionConfig);
            });

            _mainMenuView.OnLifeQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _mainMenuView.SceneTransitionSignal
                    .OnNext(_mainMenuModel.QuestionsConfig.LifeQuestionConfig);
            });

            _mainMenuView.OnDreamQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _mainMenuView.SceneTransitionSignal
                    .OnNext(_mainMenuModel.QuestionsConfig.DreamsQuestionConfig);
            });

            _mainMenuView.OnChurchQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _mainMenuView.SceneTransitionSignal
                    .OnNext(_mainMenuModel.QuestionsConfig.ChurchQuestionConfig);
            });
        }

        private void UpdateQuestionsCount()
        {
            _mainMenuView.ShowGirlsQuestionsCount(_mainMenuModel.GirlsQuestions);
            _mainMenuView.ShowBoysQuestionsCount(_mainMenuModel.BoysQuestions);
            _mainMenuView.ShowLoversQuestionsCount(_mainMenuModel.LoverQuestions);
            _mainMenuView.ShowFunnyQuestionsCount(_mainMenuModel.FunnyQuestions);
            _mainMenuView.ShowArtistQuestionsCount(_mainMenuModel.ArtQuestions);
            _mainMenuView.ShowLifeQuestionsCount(_mainMenuModel.LifeQuestions);
            _mainMenuView.ShowDreamQuestionsCount(_mainMenuModel.DreamQuestions);
            _mainMenuView.ShowChurchQuestionsCount(_mainMenuModel.ChurchQuestions);
        }
    }
}
