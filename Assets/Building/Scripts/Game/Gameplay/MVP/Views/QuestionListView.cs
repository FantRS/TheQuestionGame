using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MainSpace.MainMenu.Views
{
    public sealed class QuestionListView : MonoBehaviour
    {
        [SerializeField] private GameObject _mainTab;
        [SerializeField] private GameObject _questionTab;

        [SerializeField] private CanvasGroup _mainGroup;
        [SerializeField] private CanvasGroup _questionGroup;

        [SerializeField] private Transform _contentListTransform;
        [SerializeField] private ButtonView _buttonPrefab;
        [SerializeField] private Button _toMainTabButton;
        [SerializeField] private Image _handleImage;

        public event Action OnToMainTabButtonClickEvent;
        public event Action<int> OnQuestionButtonClickEvent;

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
            var buttonView = Instantiate(_buttonPrefab, _contentListTransform);

            var currentText = buttonView.CurrentText;
            var currentButton = buttonView.CurrentButton;

            currentText.text = text;
            currentText.color = color;

            currentButton.onClick.AddListener(() =>
            {
                OnQuestionButtonClickEvent?.Invoke(idx);
            });
        }

        public void CloseList()
        {
            DisableGroup(_questionGroup);
            EnableGroup(_mainGroup);
        }

        private void DisableGroup(CanvasGroup group)
        {
            group.blocksRaycasts = false;
            group.interactable = false;
            group.DOFade(0, 0.15f);
        }

        private void EnableGroup(CanvasGroup group)
        {
            group.blocksRaycasts = true;
            group.interactable = true;
            group.DOFade(1, 0.15f);
        }
    }
}
