using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Views;
using R3;
using System.Collections.Generic;
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

            Shuffle(_screenModel.Questions);

            _screenView.OnNextQuestionButtonClickEvent += ItarateQuestionsList;

            _screenModel.CurrentIdx.Subscribe((value) =>
            {
                _screenView.ChangeQuestionText(_screenModel.Questions[value]);
            });
        }

        private void ItarateQuestionsList()
        {
            if (_screenModel.CurrentIdx.Value + 1 == _screenModel.Questions.Count)
            {
                _screenModel.CurrentIdx.Value = 0;
            }
            else
            {
                _screenModel.CurrentIdx.Value++;
            }
        }

        private void Shuffle(List<string> questions)
        {
            int n = questions.Count;

            for (int i = n - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);

                string temp = questions[i];
                questions[i] = questions[j];
                questions[j] = temp;
            }
        }
    }
}
