using R3;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MainSpace.MainMenu.Views
{
    public sealed class ScreenView : MonoBehaviour
    {
        [SerializeField] private Text _screenName;
        [SerializeField] private Image _background;
        [SerializeField] private Text _questionText;

        [SerializeField] private Button _nextQuestionButton;
        [SerializeField] private Button _backButton;

        public event Action OnNextQuestionButtonClickEvent;

        public Subject<Unit> SceneTransitionSignal { get; private set; }

        public void BindSceneTransitionSignal(Subject<Unit> sceneTransitionSignal)
        {
            SceneTransitionSignal = sceneTransitionSignal;
        }

        private void Start()
        {
            _nextQuestionButton.onClick.AddListener(() =>
            {
                OnNextQuestionButtonClickEvent?.Invoke();
            });

            _backButton.onClick.AddListener(() =>
            {
                SceneTransitionSignal?.OnNext(Unit.Default);
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

        public void ChangeQuestionText(string questionText)
        {
            _questionText.text = questionText;
        }
    }
}
