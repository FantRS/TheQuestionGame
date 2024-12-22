using DG.Tweening;
using R3;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MainSpace.MainMenu.Views
{
    public sealed class ScreenView : MonoBehaviour
    {
        [SerializeField] private float _fadeTime;

        [SerializeField] private CanvasGroup _mainGroup;
        [SerializeField] private CanvasGroup _listGroup;

        [SerializeField] private Image _background;
        [SerializeField] private Image _cardFormImage;

        [Header("Buttons")]
        [SerializeField] private Button _openListButton;
        [SerializeField] private Button _closeListButton;
        [SerializeField] private Button _backButton;

        // events
        public event Action OnOpenListButtonClickEvent;
        public event Action OnCloseListButtonClickEvent;

        // Subject (R3)
        public Subject<Unit> SceneTransitionSignal { get; private set; }

        private void Start()
        {
            _openListButton.onClick.AddListener(() =>
            {
                OnOpenListButtonClickEvent?.Invoke();
            });

            _closeListButton.onClick.AddListener(() =>
            {
                OnCloseListButtonClickEvent?.Invoke();
            });

            _backButton.onClick.AddListener(() =>
            {
                SceneTransitionSignal?.OnNext(Unit.Default);
            });
        }

        public void BindSceneTransitionSignal(Subject<Unit> sceneTransitionSignal)
        {
            SceneTransitionSignal = sceneTransitionSignal;
        }

        public void SetBackground(Sprite image)
        {
            _background.sprite = image;
        }

        public void SetCardFormImage(Sprite cardFormImage)
        {
            _cardFormImage.sprite = cardFormImage;
        }

        public void SetButtonsColor(Color color)
        {
            _openListButton.GetComponent<Image>().color = color;
            _backButton.GetComponent<Image>().color = color;
        }

        public void OpenList()
        {
            DisableGroup(_mainGroup);
            EnableGroup(_listGroup);
        }

        public void CloseList()
        {
            DisableGroup(_listGroup);
            EnableGroup(_mainGroup);
        }

        private void DisableGroup(CanvasGroup group)
        {
            group.blocksRaycasts = false;
            group.interactable = false;
            group.DOFade(0, _fadeTime);
        }

        private void EnableGroup(CanvasGroup group)
        {
            group.blocksRaycasts = true;
            group.interactable = true;
            group.DOFade(1, _fadeTime);
        }
    }
}
