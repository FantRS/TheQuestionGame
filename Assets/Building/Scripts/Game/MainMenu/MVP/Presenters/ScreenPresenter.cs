using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Views;
using R3;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MainSpace.MainMenu.Presenters
{
    public sealed class ScreenPresenter : IDisposable
    {
        private readonly ScreenView _screenView;
        private readonly ScreenModel _screenModel;

        public ScreenPresenter(ScreenView view, ScreenModel model)
        {
            _screenView = view;
            _screenModel = model;

            Shuffle(_screenModel.Questions);

            EventSubscriptions();
            ReactiveSubscriptions();
        }

        private void EventSubscriptions()
        {
            _screenView.OnNextQuestionButtonClickEvent += ItarateQuestionsList;
        }

        private void ReactiveSubscriptions()
        {
            IDisposable subscription;

            subscription = _screenModel.CurrentIdx.Subscribe((value) =>
            {
                _screenView.ChangeQuestionText(_screenModel.Questions[value]);
            });
            _screenModel.Subscriptions.Add(subscription);
        }

        private void ItarateQuestionsList()
        {
            Debug.Log(_screenModel.CurrentIdx.Value);

            int currentIdx = _screenModel.CurrentIdx.Value;
            int questionCount = _screenModel.Questions.Count;

            if (currentIdx + 1 == questionCount)
                _screenModel.CurrentIdx.Value = 0;
            else
                _screenModel.CurrentIdx.Value++;
        }

        private void Shuffle(List<string> questions)
        {
            int n = questions.Count;

            for (int i = n - 1; i > 0; i--)
            {
                int j = UnityEngine.Random.Range(0, i + 1);

                string temp = questions[i];
                questions[i] = questions[j];
                questions[j] = temp;
            }
        }

        public void Dispose()
        {
            Debug.Log("Disposing...");

            _screenView.OnNextQuestionButtonClickEvent -= ItarateQuestionsList;

            _screenModel.Subscriptions.Dispose();

            Debug.Log("Disposed!");
        }
    }
}
