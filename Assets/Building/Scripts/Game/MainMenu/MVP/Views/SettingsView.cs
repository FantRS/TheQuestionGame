using R3;
using UnityEngine;
using UnityEngine.UI;

namespace MainSpace.MainMenu.Views
{
    public sealed class SettingsView : MonoBehaviour
    {
        [SerializeField] private Button _clearFavouriteListButton;
        [SerializeField] private Toggle _isShuffledModeToggle;

        public readonly Subject<Unit> OnClearFavouriteListButtonClickEvent = new();
        public readonly Subject<bool> OnShuffleModeToggleClick = new();

        private void Start()
        {
            _clearFavouriteListButton.onClick.AddListener(() =>
            {
                OnClearFavouriteListButtonClickEvent.OnNext(Unit.Default);
            });

            _isShuffledModeToggle.onValueChanged.AddListener((value) =>
            {
                OnShuffleModeToggleClick?.OnNext(value);
            });
        }

        public void ChangeShuffleModeToggleValue(bool value)
        {
            _isShuffledModeToggle.isOn = value;
        }
    }
}
