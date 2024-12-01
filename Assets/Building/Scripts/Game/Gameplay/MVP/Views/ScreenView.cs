using R3;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MainSpace.MainMenu.Views
{
    public sealed class ScreenView : MonoBehaviour
    {
        [Header("\tMainTab")]
        [SerializeField] private GameObject _mainTab;
        [SerializeField] private GameObject _listTab;

        [SerializeField] private Image _background;
        [SerializeField] private Image _cardImage;
        [SerializeField] private Text _categoryTitle;
        [SerializeField] private Text _questionText;

        [Header("Buttons")]
        [SerializeField] private Button _nextQuestionButton;
        [SerializeField] private Button _addToFavouriteButton;
        [SerializeField] private Button _openListButton;
        [SerializeField] private Button _backButton;

        [SerializeField] private Image _starImage;
        [SerializeField] private Sprite _starNotFilledSprite;
        [SerializeField] private Sprite _starFilledSprite;

        // events
        public event Action OnNextQuestionButtonClickEvent;
        public event Action OnAddToFavouriteButtonClickEvent;
        public event Action OnOpenListButtonClickEvent;

        // Subject (R3)
        public Subject<Unit> SceneTransitionSignal { get; private set; }

        private void Start()
        {
            // main tab elements
            _nextQuestionButton.onClick.AddListener(() =>
            {
                OnNextQuestionButtonClickEvent?.Invoke();
            });

            _addToFavouriteButton.onClick.AddListener(() =>
            {
                OnAddToFavouriteButtonClickEvent?.Invoke();
            });

            _openListButton.onClick.AddListener(() =>
            {
                OnOpenListButtonClickEvent?.Invoke();
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

        public void SetCardSprite(Sprite image)
        {
            _cardImage.sprite = image;
        }

        public void SetScreenName(string screenName)
        {
            _categoryTitle.text = screenName;
        }

        public void SetTextColor(Color color)
        {
            _categoryTitle.color = color;
            _questionText.color = color;
        }

        public void SetButtonsColor(Color color)
        {
            _openListButton.GetComponent<Image>().color = color;
            _backButton.GetComponent<Image>().color = color;
        }

        public void SetActiveMainTab(bool active)
        {
            _mainTab.SetActive(active);
        }

        public void SetActiveListTab(bool active)
        {
            _listTab.SetActive(active);
        }

        public void ChangeQuestionText(string questionText)
        {
            _questionText.text = questionText;
        }

        public void EnableFilledStar()
        {
            _starImage.sprite = _starFilledSprite;
        }

        public void DisableFilledStar()
        {
            _starImage.sprite = _starNotFilledSprite;
        }
    }
}
