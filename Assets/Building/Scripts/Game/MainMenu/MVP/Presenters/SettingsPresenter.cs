using MainSpace.DataStructures;
using MainSpace.MainMenu.Views;
using ObservableCollections;
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
                var questionList = model.FafouriteListData.QuestionsList;
                ClearFavouriteList(questionList);
            });

            _settingsView.OnShuffleModeButtonClickEvent.Subscribe(_ =>
            {
                var isShuffleMode = model.SettingsData.IsShuffeMode;
                OnShuffleModeButtonClick(isShuffleMode);
            });
        }

        private void ReactSubscriptions()
        {
            var view = _settingsView;
            var model = _settingsModel;

            _settingsModel.SettingsData.IsShuffeMode.Subscribe((value) =>
            {
                if (value)
                    view.ChangeShuffleButtonState(model.SHUFFLE_BUTTON_STATE_TRUE);
                else
                    view.ChangeShuffleButtonState(model.SHUFFLE_BUTTON_STATE_FALSE);
            });
        }
        
        private void ClearFavouriteList(ObservableList<Question> questionList)
        {
            questionList.Clear();
        }

        private void OnShuffleModeButtonClick(ReactiveProperty<bool> shuffleMode)
        {
            shuffleMode.Value = !shuffleMode.CurrentValue;
        }
    }
}
