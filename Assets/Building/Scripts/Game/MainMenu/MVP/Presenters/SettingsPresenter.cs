using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Views;

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

        }
    }
}
