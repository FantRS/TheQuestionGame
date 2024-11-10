using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Views;
using UnityEngine;

namespace MainSpace.MainMenu.Presenters
{
    public sealed class ScreenPresenter
    {
        private readonly ScreenView _screenView;
        private readonly ScreenModel _screenModel;

        public ScreenPresenter(ScreenView view, ScreenModel model)
        {
            _screenView = view;
            _screenModel = model;

            _screenView.OnRandomQuestionButtonClickEvent += ViewRandomQuestion;
        }

        private void ViewRandomQuestion()
        {
            int randIndex = GetRandomQuestion();
            _screenView.ChangeQuestionText(_screenModel.Config.QuestionList[randIndex]);
        }

        private int GetRandomQuestion()
        {
            int questionCount = _screenModel.Config.QuestionList.Count;
            return Random.Range(0, questionCount);
        }
    }
}
