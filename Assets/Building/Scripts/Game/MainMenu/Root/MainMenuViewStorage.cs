using MainSpace.MainMenu.Views;
using UnityEngine;

namespace MainSpace.MainMenu.Root
{
    public sealed class MainMenuViewStorage : MonoBehaviour
    {
        [SerializeField] private MainMenuView _mainMenuView;
        [SerializeField] private SettingsView _settingsView;

        public MainMenuView MainMenuView => _mainMenuView;
        public SettingsView SettingsView => _settingsView;
    }
}
