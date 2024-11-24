using MainSpace.Configs;
using MainSpace.DataStructures;
using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Views;
using R3;
using System;

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
            SetScreen(_screenModel.Config);
            OnFavouriteCategory(_screenModel.Config);

            // some logic...
            SpawnList();
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
                _screenView.ChangeQuestionText(questionString);
            });
            _screenModel.Subscriptions.Add(subscription);
        }

        private void OnFavouriteCategory(ScreenConfig config)
        {
            if (config.Category == Category.Favourite)
            {
                _screenView.DisableAddToFavouriteButton();
            }
        }

        private void SetScreen(ScreenConfig config)
        {
            _screenView.SetScreenName(config.ScreenName, config.QuestionTextColor);
            _screenView.SetBackground(config.Background);
            _screenView.SetQuestionTextColor(config.QuestionTextColor);
        }

        private void SpawnList()
        {
            // at the moment these lists are not shuffled!
            var shuffledStrings = _screenModel.ShuffledStringsList;
            var shuffledQuestions = _screenModel.ShuffledQuestionsList;
            int idx = 0;

            foreach (var text in shuffledStrings)
            {
                // spawn button
                _screenView.AddButtonToContent(text, idx);

                // add question to questions list in the model
                shuffledQuestions.Add(new Question(idx, _screenModel.Config.Category));

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
                _screenModel.FavouriteDataProxy.QuestionsList.Add(currentQuestion);
            }
            else
            {
                _screenModel.FavouriteDataProxy.QuestionsList.Remove(currentQuestion);
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
                _screenModel.CurrentIndex.Value++;
        }
    }
}
