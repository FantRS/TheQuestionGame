using MainSpace.Configs;
using MainSpace.DataStructures;
using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Views;
using System.Collections.Generic;

namespace MainSpace.MainMenu.Presenters
{
    public sealed class ScreenPresenter
    {
        private readonly ScreenView _screenView;
        private readonly ScreenModel _screenModel;

        public ScreenPresenter(ScreenView view, ScreenModel model)
        {
            // init view and model
            _screenView = view;
            _screenModel = model;

            // setup screen UI
            SetupScreen(_screenModel.Config);

            // some logic...
            InitializeShuffledQuestionList(_screenModel.Config);
            Shuffle(_screenModel.SettingsDataProxy.IsShuffeMode.CurrentValue);

            // subscriptions
            EventSubscriptions();
        }

        private void EventSubscriptions()
        {
            _screenView.OnOpenListButtonClickEvent += OnOpenListButtonClick;
        }

        private void SetupScreen(ScreenConfig config)
        {
            _screenView.SetBackground(config.Background);
            _screenView.SetCardFormImage(config.CardSprite);
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

        private void OnOpenListButtonClick()
        {
            _screenView.SetActiveMainTab(false);
            _screenView.SetActiveListTab(true);
        }

        private void Shuffle(bool isShuffled)
        {
            if (isShuffled)
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
        }
    }
}
