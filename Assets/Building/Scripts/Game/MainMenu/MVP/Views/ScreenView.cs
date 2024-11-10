using System;
using UnityEngine;
using UnityEngine.UI;

namespace MainSpace.MainMenu.Views
{
    public sealed class ScreenView : MonoBehaviour
    {
        [SerializeField] private Text _questionText;
        [SerializeField] private GameObject _mainMenuScreen;

        [SerializeField] private Button _nextQuestionButton;
        [SerializeField] private Button _backButton;

        public event Action OnNextQuestionButtonClickEvent;

        private void OnEnable()
        {
            Debug.Log("OnEnable : ScreenView");

            _nextQuestionButton.onClick.AddListener(() =>
            {
                OnNextQuestionButtonClickEvent?.Invoke();
            });

            _backButton.onClick.AddListener(() =>
            {
                _mainMenuScreen.SetActive(true);
                this.gameObject.SetActive(false);
            });
        }

        private void OnDisable()
        {
            Debug.Log("Disable : ScreenView");

            OnNextQuestionButtonClickEvent = null;
        }

        public void ChangeQuestionText(string questionText)
        {
            _questionText.text = questionText;
        }
    }
}
