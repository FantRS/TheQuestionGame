using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Views;
using UnityEngine;

namespace MainSpace.MainMenu.Presenters
{
    public sealed class QuestionListPresenter
    {
        private readonly QuestionListView _listView;
        private readonly ScreenModel _screenModel;

        public QuestionListPresenter(QuestionListView view, ScreenModel model)
        {
            _listView = view;
            _screenModel = model;

            _listView.SetButtonsColor(_screenModel.Config.ButtonColor);
            _listView.SetHandleColor(_screenModel.Config.ContrastColor);

            SpawnButtonList();
            EventSubscriptions();
        }

        private void EventSubscriptions()
        {
            _listView.OnToMainTabButtonClickEvent += OnToMainTabButtonClick;
            _listView.OnQuestionButtonClickEvent += OnQuestionButtonClick;
        }

        private void OnToMainTabButtonClick()
        {
            _listView.SetActiveMainTab(true);
            _listView.SetActiveListTab(false);
        }

        private void OnQuestionButtonClick(int sortedIndex)
        {
            _listView.SetActiveMainTab(true);
            _listView.SetActiveListTab(false);

            string sortedQuestionString = _screenModel.Config.QuestionList[sortedIndex];
            int newIndex = _screenModel.ShuffledStringsList.IndexOf(sortedQuestionString);
            _screenModel.CurrentIndex.OnNext(newIndex);
        }

        private void SpawnButtonList()
        {
            int sortedIndex = 0;
            var sortedStrings = _screenModel.Config.QuestionList;
            Color buttonColor = _screenModel.Config.ContrastColor;

            foreach (var text in sortedStrings)
            {
                string buttonText = $"{sortedIndex + 1}. {text}";

                // spawn button
                _listView.AddButtonToContent(buttonText, sortedIndex, buttonColor);
                sortedIndex++;
            }
        }
    }
}
