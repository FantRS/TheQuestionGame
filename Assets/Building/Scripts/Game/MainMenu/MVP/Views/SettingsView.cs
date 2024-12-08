using R3;
using UnityEngine;
using UnityEngine.UI;

namespace MainSpace.MainMenu.Views
{
    public sealed class SettingsView : MonoBehaviour
    {
        [SerializeField] private Button _shuffleModeButton;
        [SerializeField] private Button _clearFavouriteListButton;

        [SerializeField] private Text _shuffleButtonText;

        public readonly Subject<Unit> OnShuffleModeButtonClickEvent = new();
        public readonly Subject<Unit> OnClearFavouriteListButtonClickEvent = new();

        public readonly Subject<Unit> DisposeEvent = new();

        private void Start()
        {
            _shuffleModeButton.onClick.AddListener(() =>
            {
                OnShuffleModeButtonClickEvent.OnNext(Unit.Default);
            });

            _clearFavouriteListButton.onClick.AddListener(() =>
            {
                OnClearFavouriteListButtonClickEvent.OnNext(Unit.Default);
            });

            this.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            DisposeEvent.OnNext(Unit.Default);
        }

        public void ChangeShuffleButtonState(string state)
        {
            _shuffleButtonText.text = state;
        }
    }
}
