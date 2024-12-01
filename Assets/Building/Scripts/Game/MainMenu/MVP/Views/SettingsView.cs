using R3;
using UnityEngine;
using UnityEngine.UI;

namespace MainSpace.MainMenu.Views
{
    public sealed class SettingsView : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenuScreen;
        [SerializeField] private GameObject _settingsScreen;

        [SerializeField] private Button _openMainMenuScreenButton;

        public readonly Subject<Unit> OnOpenMainMenuScreenButtonClickEvent = new();

        private void Start()
        {
            _openMainMenuScreenButton.onClick.AddListener(() =>
            {
                OnOpenMainMenuScreenButtonClickEvent?.OnNext(Unit.Default);
            });
        }

        public void OpenMainMenuScreen()
        {
            _mainMenuScreen.SetActive(true);
            _settingsScreen.SetActive(false);
        }
    }
}
