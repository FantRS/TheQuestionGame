using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Views;
using R3;
using System;

namespace MainSpace.MainMenu.Presenters
{
    public sealed class SwipeCardPresenter
    {
        private readonly SwipeCardView _swipeCardView;
        private readonly ScreenModel _screenModel;

        public SwipeCardPresenter(SwipeCardView view, ScreenModel model)
        {
            _swipeCardView = view;
            _screenModel = model;

            EventSubscriptions();
        }

        private void EventSubscriptions()
        {
            var model = _screenModel;

            _screenModel.CurrentIndex.Skip(1).Subscribe(value =>
            {
                SetCard(value);
            });

            _swipeCardView.OnStartEvent.Subscribe(_ =>
            {
                SetCard(model.CurrentIndex.CurrentValue);
            });

            _swipeCardView.OnEndDragEvent.Subscribe(value =>
            {
                OnEndDrag(value);
            });
        }

        private void OnEndDrag(bool isNext)
        {
            _swipeCardView.InstantiateCard();

            if (isNext)
            {
                MoveToNextQuestion();
            }
            else
            {
                MoveToPreviousQuestion();
            }
        }

        private void SetCard(int index)
        {
            ScreenModel model = _screenModel;

            _swipeCardView.SetText(
                model.ShuffledStringsList[index], 
                model.Config.ScreenName,
                model.ShuffledQuestionsList[index].Index + 1);

            _swipeCardView.SetColorText(model.Config.ContrastColor);
            _swipeCardView.SetCardImage(model.Config.CardSprite);

            CheckFavouriteButton(index);

            _swipeCardView.AddListenerInStarButton(() => OnStarButtonClick());
;        }

        private void CheckFavouriteButton(int index)
        {
            var questionListProxy = _screenModel.FavouriteDataProxy.QuestionsList;
            var shuffledQuestionList = _screenModel.ShuffledQuestionsList;

            if (questionListProxy.Contains(shuffledQuestionList[index]))
            {
                _swipeCardView.SetFilledStarButton();
            }
            else
            {
                _swipeCardView.SetNotFilledStarButton();
            }
        }

        private void OnStarButtonClick()
        {
            var favouriteList = _screenModel.FavouriteDataProxy.QuestionsList;

            int currentIndex = _screenModel.CurrentIndex.CurrentValue;
            var currentQuestion = _screenModel.ShuffledQuestionsList[currentIndex];

            if (!favouriteList.Contains(currentQuestion))
            {
                favouriteList.Add(currentQuestion);
                _swipeCardView.SetFilledStarButton();
            }
            else
            {
                favouriteList.Remove(currentQuestion);
                _swipeCardView.SetNotFilledStarButton();
            }

            CheckFavouriteButton(currentIndex);
        }

        private void MoveToNextQuestion()
        {
            int currentIdx = _screenModel.CurrentIndex.Value;
            int questionsCount = _screenModel.ShuffledQuestionsList.Count;

            if (currentIdx + 1 == questionsCount)
                _screenModel.CurrentIndex.Value = 0;
            else
                _screenModel.CurrentIndex.Value += 1;
        }

        private void MoveToPreviousQuestion()
        {
            int currentIdx = _screenModel.CurrentIndex.Value;
            int questionsCount = _screenModel.ShuffledQuestionsList.Count;

            if (currentIdx == 0)
                _screenModel.CurrentIndex.Value = questionsCount - 1;
            else
                _screenModel.CurrentIndex.Value -= 1;
        }
    }
}
