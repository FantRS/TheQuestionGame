using System;
using UnityEngine;
using UnityEngine.UI;

namespace MainSpace.MainMenu.Views
{
    public sealed class MainMenuView : MonoBehaviour
    {
        [Header("BUTTONS")]
        [SerializeField] private Button _forGirlsQuestionsButton;
        [SerializeField] private Button _forBoysQuestionsButton;

        [Header("SCREENS")]
        [SerializeField] private GameObject _forGirlsQuestionsScreen;
        [SerializeField] private GameObject _forBoysQuestionsScreen;

        public event Action OnForGirlsQuestionsButtonClickEvent;
        public event Action OnForBoysQuestionsButtonClickEvent;

        private void Start()
        {
            _forGirlsQuestionsButton.onClick.AddListener(() =>
            {
                OnForGirlsQuestionsButtonClickEvent?.Invoke();
            });

            _forBoysQuestionsButton.onClick.AddListener(() =>
            {
                OnForBoysQuestionsButtonClickEvent?.Invoke();
            });
        }

        public void OpenGirlsQuestionsScreen()
        {
            _forGirlsQuestionsScreen.SetActive(true);
        }

        public void OpenBoysQuestionsScreen()
        {
            _forBoysQuestionsScreen.SetActive(true);
        }
    }
}
