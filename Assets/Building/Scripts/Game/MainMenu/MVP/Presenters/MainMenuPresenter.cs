using MainSpace.Configs;
using MainSpace.DataStructures;
using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Views;
using R3;
using UnityEngine;

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

            InitializeFavoriteConfig();
            EventSubsctiptions();
            UpdateQuestionsCount();
        }

        private void EventSubsctiptions()
        {
            _mainMenuView.FavouriteQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _mainMenuView.SceneTransitionSignal
                    .OnNext(_mainMenuModel.QuestionsVaultConfig.FavouriteConfig);
            });

            _mainMenuView.OnForGirlsQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _mainMenuView.SceneTransitionSignal
                    .OnNext(_mainMenuModel.QuestionsVaultConfig.ForGirlsQuestionConfig);
            });

            _mainMenuView.OnForBoysQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _mainMenuView.SceneTransitionSignal
                    .OnNext(_mainMenuModel.QuestionsVaultConfig.ForBoysQuestionConfig);
            });

            _mainMenuView.OnForLoversQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _mainMenuView.SceneTransitionSignal
                    .OnNext(_mainMenuModel.QuestionsVaultConfig.ForLoversQuestionConfig);
            });

            _mainMenuView.OnFunnyQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _mainMenuView.SceneTransitionSignal
                    .OnNext(_mainMenuModel.QuestionsVaultConfig.FunnyQuestionConfig);
            });

            _mainMenuView.OnArtistQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _mainMenuView.SceneTransitionSignal
                    .OnNext(_mainMenuModel.QuestionsVaultConfig.ArtistsQuestionConfig);
            });

            _mainMenuView.OnLifeQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _mainMenuView.SceneTransitionSignal
                    .OnNext(_mainMenuModel.QuestionsVaultConfig.LifeQuestionConfig);
            });

            _mainMenuView.OnDreamQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _mainMenuView.SceneTransitionSignal
                    .OnNext(_mainMenuModel.QuestionsVaultConfig.DreamsQuestionConfig);
            });

            _mainMenuView.OnChurchQuestionsButtonClickEvent.Subscribe(_ =>
            {
                _mainMenuView.SceneTransitionSignal
                    .OnNext(_mainMenuModel.QuestionsVaultConfig.ChurchQuestionConfig);
            });
        }

        private void UpdateQuestionsCount()
        {
            _mainMenuView.ShowFavouriteQuestionsCount(_mainMenuModel.FavouriteCount);
            _mainMenuView.ShowGirlsQuestionsCount(_mainMenuModel.GirlsCount);
            _mainMenuView.ShowBoysQuestionsCount(_mainMenuModel.BoysCount);
            _mainMenuView.ShowLoversQuestionsCount(_mainMenuModel.LoverCount);
            _mainMenuView.ShowFunnyQuestionsCount(_mainMenuModel.FunnyCount);
            _mainMenuView.ShowArtistQuestionsCount(_mainMenuModel.ArtCount);
            _mainMenuView.ShowLifeQuestionsCount(_mainMenuModel.LifeCount);
            _mainMenuView.ShowDreamQuestionsCount(_mainMenuModel.DreamCount);
            _mainMenuView.ShowChurchQuestionsCount(_mainMenuModel.WhoCount);
        }

        private void InitializeFavoriteConfig()
        {
            _mainMenuModel.QuestionsVaultConfig.FavouriteConfig.QuestionList.Clear();

            var questionVaultConfig = _mainMenuModel.QuestionsVaultConfig;
            var favouriteQuestions = _mainMenuModel.FavouriteQuestionsProxy.QuestionsList;

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

                _mainMenuModel.QuestionsVaultConfig.FavouriteConfig.QuestionList
                    .Add(questionString);
            }

            CheckFavouriteButton();
        }

        private void CheckFavouriteButton()
        {
            if (_mainMenuModel.FavouriteCount == 0)
            {
                _mainMenuView.DisableButton();
            }
        }
    }
}
