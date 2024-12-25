using MainSpace.Configs;
using MainSpace.DataStructures;
using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Views;
using ObservableCollections;
using R3;
using System;
using UnityEngine;

namespace MainSpace.MainMenu.Presenters
{
    public sealed class MainMenuPresenter : IDisposable
    {
        private readonly MainMenuView _menuView;
        private readonly MainMenuModel _menuModel;

        public MainMenuPresenter(MainMenuView view, MainMenuModel model)
        {
            // init view and model
            _menuView = view;
            _menuModel = model;

            // subscriptions
            EventSubsctiptions();
            ReactiveSubscriptions();

            // some logic...
            InitializeFavoriteConfig();
            CheckFavouriteButton();
        }

        private void EventSubsctiptions()
        {
            var view = _menuView;

            _menuView.DisposeEvent.Subscribe(_ =>
            {
                Dispose();
            });

            _menuView.FavouriteQuestionsButtonClickEvent.Subscribe(_ =>
            {
                InitializeFavoriteConfig();

                view.SceneTransitionSignal
                    .OnNext(_menuModel.VaultConfig.FavouriteConfig);
            });

            _menuView.OnForGirlsQuestionsButtonClickEvent.Subscribe(_ =>
            {
                view.SceneTransitionSignal
                    .OnNext(_menuModel.VaultConfig.ForGirlsQuestionConfig);
            });

            _menuView.OnForBoysQuestionsButtonClickEvent.Subscribe(_ =>
            {
                view.SceneTransitionSignal
                    .OnNext(_menuModel.VaultConfig.ForBoysQuestionConfig);
            });

            _menuView.OnForLoversQuestionsButtonClickEvent.Subscribe(_ =>
            {
                view.SceneTransitionSignal
                    .OnNext(_menuModel.VaultConfig.ForLoversQuestionConfig);
            });

            _menuView.OnArtistQuestionsButtonClickEvent.Subscribe(_ =>
            {
                view.SceneTransitionSignal
                    .OnNext(_menuModel.VaultConfig.ArtistsQuestionConfig);
            });

            _menuView.OnLifeQuestionsButtonClickEvent.Subscribe(_ =>
            {
                view.SceneTransitionSignal
                    .OnNext(_menuModel.VaultConfig.LifeQuestionConfig);
            });

            _menuView.OnDreamQuestionsButtonClickEvent.Subscribe(_ =>
            {
                view.SceneTransitionSignal
                    .OnNext(_menuModel.VaultConfig.DreamsQuestionConfig);
            });

            _menuView.OnFamilyQuestionsButtonClickEvent.Subscribe(_ =>
            {
                view.SceneTransitionSignal
                    .OnNext(_menuModel.VaultConfig.FamilyQuestionConfig);
            });

            _menuView.OnWhichOfQuestionsButtonClickEvent.Subscribe(_ =>
            {
                view.SceneTransitionSignal
                    .OnNext(_menuModel.VaultConfig.WhichOfQuestionConfig);
            });
        }

        private void ReactiveSubscriptions()
        {
            var view = _menuView;
            var model = _menuModel;

            _menuModel.FavouriteCount.Subscribe((value) => view.ShowFavouriteQuestionsCount(value));
            _menuModel.GirlsCount.Subscribe((value) => view.ShowGirlsQuestionsCount(value));
            _menuModel.BoysCount.Subscribe((value) => view.ShowBoysQuestionsCount(value));
            _menuModel.LoverCount.Subscribe((value) => view.ShowLoversQuestionsCount(value));
            _menuModel.ArtCount.Subscribe((value) => view.ShowArtistQuestionsCount(value));
            _menuModel.LifeCount.Subscribe((value) => view.ShowLifeQuestionsCount(value));
            _menuModel.DreamCount.Subscribe((value) => view.ShowDreamQuestionsCount(value));
            _menuModel.FamilyCount.Subscribe((value) => view.ShowFamilyQuestionsCount(value));
            _menuModel.WhichOfCount.Subscribe((value) => view.ShowWhichOfQuestionsCount(value));

            model.CompositeDisposable.Add(_menuModel.FavouriteQuestionsProxy.QuestionsList.ObserveClear().Subscribe(_ =>
            {
                int count = model.FavouriteQuestionsProxy.QuestionsList.Count;

                model.FavouriteCount.OnNext(count);
                view.DisableFavouriteButton();
            }));
        }

        private void InitializeFavoriteConfig()
        {
            var questionVaultConfig = _menuModel.VaultConfig;
            var favouriteQuestions = _menuModel.FavouriteQuestionsProxy.QuestionsList;

            questionVaultConfig.FavouriteConfig.QuestionList.Clear();

            foreach (var question in favouriteQuestions)
            {
                ScreenConfig categoryConfig = question.Category switch
                {
                    Category.Boys => questionVaultConfig.ForBoysQuestionConfig,
                    Category.Girls => questionVaultConfig.ForGirlsQuestionConfig,
                    Category.Lovers => questionVaultConfig.ForLoversQuestionConfig,
                    Category.Art => questionVaultConfig.ArtistsQuestionConfig,
                    Category.Life => questionVaultConfig.LifeQuestionConfig,
                    Category.Dream => questionVaultConfig.DreamsQuestionConfig,
                    Category.WhichOf => questionVaultConfig.WhichOfQuestionConfig,
                    _ => throw new Exception($"{this} : Not found any question")
                };

                // in case of missing questions from the category
                if (question.Index >= categoryConfig.QuestionList.Count || question.Index < 0)
                {
                    questionVaultConfig.FavouriteConfig.QuestionList.Clear();
                    favouriteQuestions.Clear();
                    return;
                }

                string questionString = categoryConfig.QuestionList[question.Index];

                questionVaultConfig.FavouriteConfig.QuestionList
                    .Add(questionString);
            }
        }

        private void CheckFavouriteButton()
        {
            if (_menuModel.VaultConfig.FavouriteConfig.QuestionList.Count == 0)
            {
                _menuView.DisableFavouriteButton();
            }
        }

        public void Dispose()
        {
            _menuModel.CompositeDisposable.Dispose();
        }
    }
}
