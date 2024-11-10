using System;
using UnityEngine;
using UnityEngine.UI;

namespace MainSpace.MainMenu.Views
{
    public sealed class ScreenView : MonoBehaviour
    {
        [SerializeField] private Text _questionText;
        [SerializeField] private GameObject _mainMenuScreen;

        [SerializeField] private Button _randomQuestionButton;
        [SerializeField] private Button _backButton;

        public event Action OnRandomQuestionButtonClickEvent;

        private void OnEnable()
        {
            Debug.Log("OnEnable : ScreenView");

            _randomQuestionButton.onClick.AddListener(() =>
            {
                OnRandomQuestionButtonClickEvent?.Invoke();
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

            OnRandomQuestionButtonClickEvent = null;
        }

        public void ChangeQuestionText(string questionText)
        {
            _questionText.text = questionText;
        }
    }
}
