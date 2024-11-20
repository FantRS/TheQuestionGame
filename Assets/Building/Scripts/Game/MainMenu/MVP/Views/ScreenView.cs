using R3;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MainSpace.MainMenu.Views
{
    public sealed class ScreenView : MonoBehaviour
    {
        [Header("MainTab")]
        [SerializeField] private GameObject _mainTab;

        [SerializeField] private Text _screenName;
        [SerializeField] private Image _background;
        [SerializeField] private Text _questionText;

        [SerializeField] private Button _nextQuestionButton;
        [SerializeField] private Button _openListButton;
        [SerializeField] private Button _backButton;


        [Header("ListTab")]
        [SerializeField] private GameObject _listTab;
        [SerializeField] private Transform _contentListTransform;
        [SerializeField] private Button _buttonPrefab;

        [SerializeField] private Button _toMainTabButton;

        // events
        public event Action OnNextQuestionButtonClickEvent;
        public event Action OnOpenListButtonClickEvent;
        public event Action OnToMainTabButtonClickEvent;
        public event Action<int> OnQuestionButtonClickEvent;

        // Subject (R3)
        public Subject<Unit> SceneTransitionSignal { get; private set; }

        public void BindSceneTransitionSignal(Subject<Unit> sceneTransitionSignal)
        {
            SceneTransitionSignal = sceneTransitionSignal;
        }

        private void Start()
        {
            // main tab elements
            _nextQuestionButton.onClick.AddListener(() =>
            {
                OnNextQuestionButtonClickEvent?.Invoke();
            });

            _openListButton.onClick.AddListener(() =>
            {
                OnOpenListButtonClickEvent?.Invoke();
            });

            _backButton.onClick.AddListener(() =>
            {
                SceneTransitionSignal?.OnNext(Unit.Default);
            });

            // list tab elements
            _toMainTabButton.onClick.AddListener(() =>
            {
                OnToMainTabButtonClickEvent?.Invoke();
            });
        }

        public void SetScreenName(string screenName, Color color)
        {
            _screenName.text = screenName;
            _screenName.color = color;
        }

        public void SetBackground(Sprite image)
        {
            _background.sprite = image;
        }

        public void SetQuestionTextColor(Color color)
        {
            _questionText.color = color;
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

        public void AddButtonToContent(string text, int idx)
        {
            var btn = Instantiate(_buttonPrefab, _contentListTransform);
            btn.gameObject.GetComponentInChildren<Text>().text = text;

            btn.onClick.AddListener(() =>
            {
                OnQuestionButtonClickEvent?.Invoke(idx);
            });
        }
    }
}
