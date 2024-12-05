using System.IO;

namespace MainSpace.Data.Root
{
    public sealed class DataProvider
    {
        // keys for store datas
        private const string FAV_QUESTIONS_DATA_KEY = nameof(FAV_QUESTIONS_DATA_KEY);
        private const string SETTINGS_DATA_KEY = nameof(SETTINGS_DATA_KEY);

        // raw datas
        private FavouriteQuestionsData _favouriteQuestionsData;
        private SettingsData _settingsData;

        // proxies
        public FavouriteQuestionsDataProxy FavouriteQuestionsDataProxy { get; private set; }
        public SettingsDataProxy SettingsDataProxy { get; private set; }


        public void SaveFavouriteQuestionData()
        {
            StorageService.Save(FAV_QUESTIONS_DATA_KEY, _favouriteQuestionsData);
        }

        public void SaveSettingsData()
        {
            StorageService.Save(SETTINGS_DATA_KEY, _settingsData);
        }


        public void LoadFavouriteQuestionData()
        {
            try
            {
                _favouriteQuestionsData = StorageService.Load<FavouriteQuestionsData>(FAV_QUESTIONS_DATA_KEY);
                FavouriteQuestionsDataProxy = new FavouriteQuestionsDataProxy(_favouriteQuestionsData);
            }
            catch (FileNotFoundException)
            {
                _favouriteQuestionsData = new FavouriteQuestionsData();
                FavouriteQuestionsDataProxy = new FavouriteQuestionsDataProxy(_favouriteQuestionsData);

                SaveFavouriteQuestionData();
            }
        }

        public void LoadSettingsData()
        {
            try
            {
                _settingsData = StorageService.Load<SettingsData>(SETTINGS_DATA_KEY);
                SettingsDataProxy = new SettingsDataProxy(_settingsData);
            }
            catch (FileNotFoundException)
            {
                _settingsData = new SettingsData();
                SettingsDataProxy = new SettingsDataProxy(_settingsData);

                SaveSettingsData();
            }
        }


        public void ResetFavouriteQuestionData()
        {
            _favouriteQuestionsData = new FavouriteQuestionsData();
            FavouriteQuestionsDataProxy = new FavouriteQuestionsDataProxy(_favouriteQuestionsData);
        }

        public void ResetSettingsData()
        {
            _settingsData = new SettingsData();
            SettingsDataProxy = new SettingsDataProxy(_settingsData);
        }
    }
}
