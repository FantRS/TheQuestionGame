using MainSpace.DataStructures;
using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Views;
using ObservableCollections;
using R3;
using System;
using UnityEngine.Localization.Settings;
using UnityEngine;

namespace MainSpace.MainMenu.Presenters
{
    public sealed class SettingsPresenter : IDisposable
    {
        private readonly SettingsView _settingsView;
        private readonly SettingsModel _settingsModel;
        private readonly MainMenuModel _mainMenuModel;

        public SettingsPresenter(SettingsView view, SettingsModel setitngsModel, MainMenuModel mainModel)
        {
            _settingsView = view;
            _settingsModel = setitngsModel;
            _mainMenuModel = mainModel;

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

            _settingsView.OnChangeLanguageButtonClick.Subscribe(_ =>
            {
                var languageID = _settingsModel.SettingsData.LanguageID;
                var availableLocales = LocalizationSettings.AvailableLocales.Locales;

                languageID.Value = languageID.CurrentValue + 1 == availableLocales.Count ?
                    0 : languageID.CurrentValue + 1;
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
            var settModel = _settingsModel;
            var mainModel = _mainMenuModel;

            settModel.CompositeDisposables.Add(settModel.SettingsData.IsShuffeMode.Subscribe((isShuffle) =>
            {
                Color color = isShuffle ? Color.green : Color.red;
                
                view.ChangeShuffleTextColor(color);
            }));

            settModel.CompositeDisposables.Add(settModel.SettingsData.LanguageID.Subscribe((languageId) =>
            {
                mainModel.ChangeLocaleVaultByLanguage(languageId);
                OnChangeLanguageButtonClick();
            }));
        }
        
        private void OnShuffleModeButtonClick(ReactiveProperty<bool> shuffleMode)
        {
            shuffleMode.Value = !shuffleMode.CurrentValue;
        }

        private void OnChangeLanguageButtonClick()
        {
            var languageID = _settingsModel.SettingsData.LanguageID.CurrentValue;
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[languageID];
        }

        private void ClearFavouriteList(ObservableList<Question> questionList)
        {
            questionList.Clear();
        }

        public void Dispose()
        {
            _settingsModel.CompositeDisposables.Dispose();
        }
    }
}
