using R3;
using UnityEngine;
using UnityEngine.UI;

namespace MainSpace.MainMenu.Views
{
    public sealed class SettingsView : MonoBehaviour
    {
        [SerializeField] private Button _clearFavouriteListButton;
        [SerializeField] private Button _shuffleModeButton;

        [SerializeField] private Text _shuffleModeButtonText;

        public readonly Subject<Unit> OnClearFavouriteListButtonClickEvent = new();
        public readonly Subject<Unit> OnShuffleModeButtonClickEvent = new();

        private void Start()
        {
            _clearFavouriteListButton.onClick.AddListener(() =>
            {
                OnClearFavouriteListButtonClickEvent.OnNext(Unit.Default);
            });

            _shuffleModeButton.onClick.AddListener(() =>
            {
                OnShuffleModeButtonClickEvent.OnNext(Unit.Default);
            });
        }

        public void ChangeShuffleButtonState(string state)
        {
            _shuffleModeButtonText.text = state;
        }
    }
}
