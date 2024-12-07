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

        [Header("Buttons")]
        [SerializeField] private Button _openListButton;
        [SerializeField] private Button _backButton;

        // events
        public event Action OnOpenListButtonClickEvent;

        // Subject (R3)
        public Subject<Unit> SceneTransitionSignal { get; private set; }

        private void Start()
        {
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
    }
}
