using MainSpace.DataStructures;
using MainSpace.MainMenu.Views;
using ObservableCollections;
using R3;
using System;

namespace MainSpace.MainMenu.Presenters
{
    public sealed class SettingsPresenter : IDisposable
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

            _settingsView.OnShuffleModeButtonClickEvent.Subscribe(_ =>
            {
                OnShuffleModeButtonClick(model.SettingsData.IsShuffeMode);
            });

            _settingsView.OnClearFavouriteListButtonClickEvent.Subscribe(_ =>
            {
                var questionList = model.FafouriteListData.QuestionsList;
                ClearFavouriteList(questionList);
            });

            _settingsView.DisposeEvent.Subscribe(_ =>
            {
                Dispose();
            });
        }

        private void ReactSubscriptions()
        {
            var view = _settingsView;
            var model = _settingsModel;

            model.CompositeDisposables.Add(model.SettingsData.IsShuffeMode.Subscribe((isShuffle) =>
            {
                string state = isShuffle ?
                    model.SHUFFLE_BUTTON_STATE_TRUE :
                    model.SHUFFLE_BUTTON_STATE_FALSE;

                view.ChangeShuffleButtonState(state);
            }));
        }
        
        private void ClearFavouriteList(ObservableList<Question> questionList)
        {
            questionList.Clear();
        }

        private void OnShuffleModeButtonClick(ReactiveProperty<bool> shuffleMode)
        {
            shuffleMode.Value = !shuffleMode.CurrentValue;
        }

        public void Dispose()
        {
            _settingsModel.CompositeDisposables.Dispose();
        }
    }
}
