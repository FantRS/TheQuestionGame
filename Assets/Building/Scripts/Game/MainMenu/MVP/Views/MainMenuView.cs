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
        [SerializeField] private Button _forLoverQuestionsButton;
        [SerializeField] private Button _funnyQuestionsButton;
        [SerializeField] private Button _artistsQuestionsButton;
        [SerializeField] private Button _lifeQuestionsButton;
        [SerializeField] private Button _dreamQuestionsButton;
        [SerializeField] private Button _churchQuestionsButton;

        [Header("SCREENS")]
        [SerializeField] private GameObject _forGirlsQuestionsScreen;
        [SerializeField] private GameObject _forBoysQuestionsScreen;
        [SerializeField] private GameObject _forLoverQuestionsScreen;
        [SerializeField] private GameObject _funnyQuestionsScreen;
        [SerializeField] private GameObject _artistsQuestionsScreen;
        [SerializeField] private GameObject _lifeQuestionsScreen;
        [SerializeField] private GameObject _dreamQuestionsScreen;
        [SerializeField] private GameObject _churchQuestionsScreen;

        // events
        public event Action OnForGirlsQuestionsButtonClickEvent;
        public event Action OnForBoysQuestionsButtonClickEvent;
        public event Action OnForLoversQuestionsButtonClickEvent;
        public event Action OnFunnyQuestionsButtonClickEvent;
        public event Action OnArtistQuestionsButtonClickEvent;
        public event Action OnLifeQuestionsButtonClickEvent;
        public event Action OnDreamQuestionsButtonClickEvent;
        public event Action OnChurchQuestionsButtonClickEvent;

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

            _forLoverQuestionsButton.onClick.AddListener(() =>
            {
                OnForLoversQuestionsButtonClickEvent?.Invoke();
            });

            _funnyQuestionsButton.onClick.AddListener(() =>
            {
                OnFunnyQuestionsButtonClickEvent?.Invoke();
            });

            _artistsQuestionsButton.onClick.AddListener(() =>
            {
                OnArtistQuestionsButtonClickEvent?.Invoke();
            });

            _lifeQuestionsButton.onClick.AddListener(() =>
            {
                OnLifeQuestionsButtonClickEvent?.Invoke();
            });

            _dreamQuestionsButton.onClick.AddListener(() =>
            {
                OnDreamQuestionsButtonClickEvent?.Invoke();
            });

            _churchQuestionsButton.onClick.AddListener(() =>
            {
                OnChurchQuestionsButtonClickEvent?.Invoke();
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

        public void OpenLoversQuestionsScreen()
        {
            _forLoverQuestionsScreen.SetActive(true);
        }

        public void OpenFunnyQuestionsScreen()
        {
            _funnyQuestionsScreen.SetActive(true);
        }

        public void OpenArtistQuestionsScreen()
        {
            _artistsQuestionsScreen.SetActive(true);
        }

        public void OpenLifeQuestionsScreen()
        {
            _lifeQuestionsScreen.SetActive(true);
        }

        public void OpenDreamQuestionsScreen()
        {
            _dreamQuestionsScreen.SetActive(true);
        }

        public void OpenChurchQuestionsScreen()
        {
            _churchQuestionsScreen.SetActive(true);
        }
    }
}
