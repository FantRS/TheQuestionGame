using MainSpace.Configs;
using MainSpace.DataStructures;
using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Views;
using R3;
using System;
using System.Collections.Generic;

namespace MainSpace.MainMenu.Presenters
{
    public sealed class ScreenPresenter
    {
        private ScreenView _screenView;
        private ScreenModel _screenModel;

        public ScreenPresenter(ScreenView view, ScreenModel model)
        {
            // init view and model
            _screenView = view;
            _screenModel = model;

            // setup screen UI
            SetupScreen(_screenModel.Config);

            // some logic...
            InitializeShuffledQuestionList(_screenModel.Config);
            SpawnButtonList(_screenModel.ShuffledStringsList);
            Shuffle();

            // subscriptions
            EventSubscriptions();
            ReactiveSubscriptions();
        }

        private void EventSubscriptions()
        {
            _screenView.OnNextQuestionButtonClickEvent += ItarateQuestionsList;
            _screenView.OnAddToFavouriteButtonClickEvent += FavouriteListControl;
            _screenView.OnOpenListButtonClickEvent += () =>
            {
                _screenView.SetActiveMainTab(false);
                _screenView.SetActiveListTab(true);
            };
            _screenView.OnToMainTabButtonClickEvent += () =>
            {
                _screenView.SetActiveMainTab(true);
                _screenView.SetActiveListTab(false);
            };
            _screenView.OnQuestionButtonClickEvent += (sortedIndex) =>
            {
                _screenView.SetActiveMainTab(true);
                _screenView.SetActiveListTab(false);

                string sortedQuestionString = _screenModel.Config.QuestionList[sortedIndex];
                int newIndex = _screenModel.ShuffledStringsList.IndexOf(sortedQuestionString);
                _screenModel.CurrentIndex.OnNext(newIndex);
            };
        }

        private void ReactiveSubscriptions()
        {
            IDisposable subscription;

            subscription = _screenModel.CurrentIndex.Subscribe((value) =>
            {
                string questionString = _screenModel.ShuffledStringsList[value];
                int questionIndex = _screenModel.ShuffledQuestionsList[value].Index + 1;
                questionIndex.ConsoleWrite();

                _screenView.ChangeQuestionText(questionString);
                CheckFavouriteQuestionState();
            });

            _screenModel.Subscriptions.Add(subscription);
        }

        private void SetupScreen(ScreenConfig config)
        {
            _screenView.SetBackground(config.Background);
            _screenView.SetCardSprite(config.CardSprite);
            _screenView.SetScreenName(config.ScreenName);
            _screenView.SetTextColor(config.ContrastColor);
            _screenView.SetButtonsColor(config.ButtonColor);
        }

        private void InitializeShuffledQuestionList(ScreenConfig config)
        {
            if (config.Category == Category.Favourite)
            {
                _screenModel.ShuffledQuestionsList = 
                    new List<Question>(_screenModel.FavouriteDataProxy.QuestionsList);
            }
            else
            {
                for (int i = 0; i < config.QuestionList.Count; i++)
                {
                    _screenModel.ShuffledQuestionsList
                        .Add(new Question(i, config.Category));
                }
            }
        }

        private void SpawnButtonList(List<string> shuffledStrings)
        {
            int idx = 0;

            foreach (var text in shuffledStrings)
            {
                // spawn button
                string buttonText = $"{idx + 1}. {text}";
                _screenView.AddButtonToContent(buttonText, idx);
                idx++;
            }
        }

        private void FavouriteListControl()
        {
            var favouriteList = _screenModel.FavouriteDataProxy.QuestionsList;

            int currentIndex = _screenModel.CurrentIndex.CurrentValue;
            var currentQuestion = _screenModel.ShuffledQuestionsList[currentIndex];

            if (!favouriteList.Contains(currentQuestion))
            {
                favouriteList.Add(currentQuestion);
                _screenView.EnableFilledStar();
            }
            else
            {
                favouriteList.Remove(currentQuestion);
                _screenView.DisableFilledStar();
            }
        }

        private void Shuffle()
        {
            // creating links to shuffled lists
            var shuffledQuestions = _screenModel.ShuffledStringsList;
            var questionsList = _screenModel.ShuffledQuestionsList;

            int n = shuffledQuestions.Count;

            for (int i = n - 1; i > 0; i--)
            {
                int j = UnityEngine.Random.Range(0, i + 1);

                // swap values in shuffled shuffledStrings
                (shuffledQuestions[i], shuffledQuestions[j]) = (shuffledQuestions[j], shuffledQuestions[i]);

                // swap values in shuffles shuffledStrings list
                (questionsList[i], questionsList[j]) = (questionsList[j], questionsList[i]);
            }
        }

        private void ItarateQuestionsList()
        {
            int currentIdx = _screenModel.CurrentIndex.Value;
            int questionCount = _screenModel.ShuffledStringsList.Count;

            if (currentIdx + 1 == questionCount)
                _screenModel.CurrentIndex.Value = 0;
            else
                _screenModel.CurrentIndex.Value += 1;
        }

        private void CheckFavouriteQuestionState()
        {
            var questionListProxy = _screenModel.FavouriteDataProxy.QuestionsList;
            int currentIndex = _screenModel.CurrentIndex.CurrentValue;

            if (questionListProxy.Contains(_screenModel.ShuffledQuestionsList[currentIndex]))
            {
                _screenView.EnableFilledStar();
            }
            else
            {
                _screenView.DisableFilledStar();
            }
        }
    }
}
