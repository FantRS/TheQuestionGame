using MainSpace.Configs;
using MainSpace.DataStructures;
using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Views;
using R3;

namespace MainSpace.MainMenu.Presenters
{
    public sealed class MainMenuPresenter
    {
        private readonly MainMenuView _menuView;
        private readonly MainMenuModel _menuModel;

        public MainMenuPresenter(MainMenuView view, MainMenuModel model)
        {
            // init view and model
            _menuView = view;
            _menuModel = model;

            // some logic...
            InitializeFavoriteConfig();

            // subscriptions
            EventSubsctiptions();
            ReactiveSubscriptions();
        }

        private void EventSubsctiptions()
        {
            _menuView.OnSettingsButtonClickEvent.Subscribe(_ =>
            {
                OnSettingsButtonClick();
            });

            _menuView.FavouriteQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _menuView.SceneTransitionSignal
                    .OnNext(_menuModel.VaultConfig.FavouriteConfig);
            });

            _menuView.OnForGirlsQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _menuView.SceneTransitionSignal
                    .OnNext(_menuModel.VaultConfig.ForGirlsQuestionConfig);
            });

            _menuView.OnForBoysQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _menuView.SceneTransitionSignal
                    .OnNext(_menuModel.VaultConfig.ForBoysQuestionConfig);
            });

            _menuView.OnForLoversQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _menuView.SceneTransitionSignal
                    .OnNext(_menuModel.VaultConfig.ForLoversQuestionConfig);
            });

            _menuView.OnFunnyQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _menuView.SceneTransitionSignal
                    .OnNext(_menuModel.VaultConfig.FunnyQuestionConfig);
            });

            _menuView.OnArtistQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _menuView.SceneTransitionSignal
                    .OnNext(_menuModel.VaultConfig.ArtistsQuestionConfig);
            });

            _menuView.OnLifeQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _menuView.SceneTransitionSignal
                    .OnNext(_menuModel.VaultConfig.LifeQuestionConfig);
            });

            _menuView.OnDreamQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _menuView.SceneTransitionSignal
                    .OnNext(_menuModel.VaultConfig.DreamsQuestionConfig);
            });

            _menuView.OnChurchQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _menuView.SceneTransitionSignal
                    .OnNext(_menuModel.VaultConfig.ChurchQuestionConfig);
            });
        }

        private void ReactiveSubscriptions()
        {
            var view = _menuView;

            _menuModel.FavouriteCount.Subscribe((value) => view.ShowFavouriteQuestionsCount(value));
            _menuModel.GirlsCount.Subscribe((value) => view.ShowGirlsQuestionsCount(value));
            _menuModel.BoysCount.Subscribe((value) => view.ShowBoysQuestionsCount(value));
            _menuModel.LoverCount.Subscribe((value) => view.ShowLoversQuestionsCount(value));
            _menuModel.FunnyCount.Subscribe((value) => view.ShowFunnyQuestionsCount(value));
            _menuModel.ArtCount.Subscribe((value) => view.ShowArtistQuestionsCount(value));
            _menuModel.LifeCount.Subscribe((value) => view.ShowLifeQuestionsCount(value));
            _menuModel.DreamCount.Subscribe((value) => view.ShowDreamQuestionsCount(value));
        }

        private void InitializeFavoriteConfig()
        {
            _menuModel.VaultConfig.FavouriteConfig.QuestionList.Clear();

            var questionVaultConfig = _menuModel.VaultConfig;
            var favouriteQuestions = _menuModel.FavouriteQuestionsProxy.QuestionsList;

            foreach (var question in favouriteQuestions)
            {
                ScreenConfig categoryConfig = question.Category switch
                {
                    Category.Boys => questionVaultConfig.ForBoysQuestionConfig,
                    Category.Girls => questionVaultConfig.ForGirlsQuestionConfig,
                    Category.Lovers => questionVaultConfig.ForLoversQuestionConfig,
                    Category.Funny => questionVaultConfig.ArtistsQuestionConfig,
                    Category.Life => questionVaultConfig.LifeQuestionConfig,
                    Category.Dream => questionVaultConfig.DreamsQuestionConfig,
                    Category.Who => questionVaultConfig.ChurchQuestionConfig,
                    _ => throw new System.Exception($"{this} : Not found any question")
                };

                // in case of missing questions from the category
                if (question.Index >= categoryConfig.QuestionList.Count)
                    continue;

                string questionString = categoryConfig.QuestionList[question.Index];

                _menuModel.VaultConfig.FavouriteConfig.QuestionList
                    .Add(questionString);
            }

            CheckFavouriteButton();
        }

        private void CheckFavouriteButton()
        {
            if (_menuModel.FavouriteCount.CurrentValue == 0)
            {
                _menuView.DisableFavouriteButton();
            }
        }

        private void OnSettingsButtonClick()
        {
            _menuView.OpenSettingsScreen();
        }
    }
}
