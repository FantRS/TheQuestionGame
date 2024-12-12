using BaCon;
using MainSpace.Configs;
using MainSpace.Data;
using MainSpace.Data.Root;
using R3;

namespace MainSpace.MainMenu.Models
{
    public sealed class MainMenuModel
    {
        private readonly LocaleMap _localeMap;

        public ScreenVaultConfig VaultConfig;
        public readonly FavouriteQuestionsDataProxy FavouriteQuestionsProxy;
        public readonly SettingsDataProxy SettingsData;

        public readonly ReactiveProperty<int> FavouriteCount;
        public readonly ReactiveProperty<int> GirlsCount;
        public readonly ReactiveProperty<int> BoysCount;
        public readonly ReactiveProperty<int> LoverCount;
        public readonly ReactiveProperty<int> FunnyCount;
        public readonly ReactiveProperty<int> ArtCount;
        public readonly ReactiveProperty<int> LifeCount;
        public readonly ReactiveProperty<int> DreamCount;

        public readonly CompositeDisposable CompositeDisposable;

        public MainMenuModel(DIContainer sceneContainer)
        {
            var dataProvider = sceneContainer.Resolve<DataProvider>();
            SettingsData = dataProvider.SettingsDataProxy;
            _localeMap = sceneContainer.Resolve<LocaleMap>();

            VaultConfig = _localeMap.GetVaultConfigByLanguage(SettingsData.LanguageID.CurrentValue);
            FavouriteQuestionsProxy = dataProvider.FavouriteQuestionsDataProxy;

            FavouriteCount = new ReactiveProperty<int>(FavouriteQuestionsProxy.QuestionsList.Count);
            GirlsCount = new ReactiveProperty<int>(VaultConfig.ForGirlsQuestionConfig.QuestionList.Count);
            BoysCount = new ReactiveProperty<int>(VaultConfig.ForBoysQuestionConfig.QuestionList.Count);
            LoverCount = new ReactiveProperty<int>(VaultConfig.ForLoversQuestionConfig.QuestionList.Count);
            FunnyCount = new ReactiveProperty<int>(VaultConfig.FunnyQuestionConfig.QuestionList.Count);
            ArtCount = new ReactiveProperty<int>(VaultConfig.ArtistsQuestionConfig.QuestionList.Count);
            LifeCount = new ReactiveProperty<int>(VaultConfig.LifeQuestionConfig.QuestionList.Count);
            DreamCount = new ReactiveProperty<int>(VaultConfig.DreamsQuestionConfig.QuestionList.Count);

            CompositeDisposable = new CompositeDisposable();
        }

        public void ChangeLocaleVaultByLanguage(int localeId)
        {
            VaultConfig = _localeMap.GetVaultConfigByLanguage(localeId);
        }
    }
}
