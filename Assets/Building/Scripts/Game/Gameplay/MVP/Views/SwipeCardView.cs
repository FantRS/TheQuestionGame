using R3;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace MainSpace.MainMenu.Views
{
    public sealed class SwipeCardView : MonoBehaviour
    {
        [SerializeField] private CardView _cardViewPrefab;

        [SerializeField] private RectTransform _parent;

        private CardView _cardView;

        public Subject<Unit> OnStartEvent = new();
        public Subject<bool> OnEndDragEvent = new();

        private void Start()
        {
            _cardView = Instantiate(_cardViewPrefab, _parent);
            _cardView.transform.SetSiblingIndex(0);

            OnStartEvent.OnNext(Unit.Default);

            _cardView.OnEndDragEvent.Subscribe(value =>
            {
                OnEndDragEvent.OnNext(value);
            });
        }

        public void InstantiateCard()
        {
            _cardView = Instantiate(_cardView, _parent);
            _cardView.transform.SetSiblingIndex(0);
            _cardView.CanvasGroup.blocksRaycasts = true;

            _cardView.OnEndDragEvent.Subscribe(value =>
            {
                OnEndDragEvent.OnNext(value);
            });
        }

        public void SetText(string question, string title, int index)
        {
            _cardView.QuestionText.text = question;
            _cardView.CategoryText.text = title;
            _cardView.CardIndex.text = index.ToString();
        }

        public void SetColorText(Color color)
        {
            _cardView.QuestionText.color = color;
            _cardView.CategoryText.color = color;
            _cardView.CardIndex.color = color;
        }

        public void SetCardImage(Sprite sprite)
        {
            _cardView.CardImage.sprite = sprite;
        }

        public void SetFilledStarButton()
        {
            _cardView.SetFilledStarButton();
        }

        public void SetNotFilledStarButton()
        {
            _cardView.SetNotFilledStarButton();
        }

        public void AddListenerInStarButton(UnityAction action)
        {
            _cardView.StarButton.onClick.AddListener(action);
        }
    }
}
