using MainSpace.MainMenu.Views;
using R3;

namespace MainSpace.MainMenu.Presenters
{
    public sealed class SettingsPresenter
    {
        private readonly SettingsView _settingsView;
        private readonly SettingsModel _settingsModel;

        public SettingsPresenter(SettingsView view, SettingsModel model)
        {
            _settingsView = view;
            _settingsModel = model;

            EventSubscriptions();
            ReactSubscriptions();
        }

        private void EventSubscriptions()
        {
            var model = _settingsModel;
            
            _settingsView.OnClearFavouriteListButtonClickEvent.Subscribe(_ =>
            {
                ClearFavouriteList();
            });

            _settingsView.OnShuffleModeToggleClick.Subscribe((value) =>
            {
                model.SettingsData.IsShuffeMode.Value = value;
            });
        }

        private void ReactSubscriptions()
        {
            var view = _settingsView;

            _settingsModel.SettingsData.IsShuffeMode.Subscribe((value) =>
            {
                view.ChangeShuffleModeToggleValue(value);
            });
        }
        
        private void ClearFavouriteList()
        {
            _settingsModel.FafouriteListData.QuestionsList.Clear();
        }
    }
}
