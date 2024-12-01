using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Views;
using R3;

namespace MainSpace.MainMenu.Presenters
{
    public sealed class SettingsPresenter
    {
        private readonly SettingsView _settingsView;
        private readonly MainMenuModel _menuModel;

        public SettingsPresenter(SettingsView view, MainMenuModel model)
        {
            _settingsView = view;
            _menuModel = model;

            ReactiveSubscriptions();
        }

        private void ReactiveSubscriptions()
        {
            _settingsView.OnOpenMainMenuScreenButtonClickEvent.Subscribe(_ =>
            {
                OnOpenMainMenuScreenButtonClick();
            });
        }

        private void OnOpenMainMenuScreenButtonClick()
        {
            _settingsView.OpenMainMenuScreen();
        }
    }
}
