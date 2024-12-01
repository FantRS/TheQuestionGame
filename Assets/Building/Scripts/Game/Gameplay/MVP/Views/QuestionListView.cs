using System;
using UnityEngine;
using UnityEngine.UI;

namespace MainSpace.MainMenu.Views
{
    public sealed class QuestionListView : MonoBehaviour
    {
        [SerializeField] private GameObject _mainTab;
        [SerializeField] private GameObject _questionTab;

        [SerializeField] private Transform _contentListTransform;
        [SerializeField] private Button _buttonPrefab;
        [SerializeField] private Button _toMainTabButton;
        [SerializeField] private Image _handleImage;

        public event Action OnToMainTabButtonClickEvent;
        public event Action<int> OnQuestionButtonClickEvent;

        private void Start()
        {
            _toMainTabButton.onClick.AddListener(() =>
            {
                OnToMainTabButtonClickEvent?.Invoke();
            });
        }

        public void SetButtonsColor(Color color)
        {
            _toMainTabButton.GetComponent<Image>().color = color;
        }

        public void SetHandleColor(Color color)
        {
            _handleImage.color = color;
        }

        public void AddButtonToContent(string text, int idx, Color color)
        {
            // creating button
            var button = Instantiate(_buttonPrefab, _contentListTransform);
            var buttonText = button.gameObject.GetComponentInChildren<Text>();

            // setup button
            buttonText.text = text;
            buttonText.color = color;

            button.onClick.AddListener(() =>
            {
                OnQuestionButtonClickEvent?.Invoke(idx);
            });
        }

        public void SetActiveMainTab(bool active)
        {
            _mainTab.SetActive(active);
        }

        public void SetActiveListTab(bool active)
        {
            _questionTab.SetActive(active);
        }
    }
}
