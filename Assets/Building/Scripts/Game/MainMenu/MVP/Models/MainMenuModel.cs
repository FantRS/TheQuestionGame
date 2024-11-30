using BaCon;
using MainSpace.Configs;
using MainSpace.Data;
using MainSpace.Data.Root;
using R3;

namespace MainSpace.MainMenu.Models
{
    public sealed class MainMenuModel
    {
        public readonly ScreenVaultConfig QuestionsVaultConfig;
        public readonly FavouriteQuestionsDataProxy FavouriteQuestionsProxy;

        public int FavouriteCount => QuestionsVaultConfig.FavouriteConfig.QuestionList.Count;
        public int GirlsCount => QuestionsVaultConfig.ForGirlsQuestionConfig.QuestionList.Count;
        public int BoysCount => QuestionsVaultConfig.ForBoysQuestionConfig.QuestionList.Count;
        public int LoverCount => QuestionsVaultConfig.ForLoversQuestionConfig.QuestionList.Count;
        public int FunnyCount => QuestionsVaultConfig.FunnyQuestionConfig.QuestionList.Count;
        public int ArtCount => QuestionsVaultConfig.ArtistsQuestionConfig.QuestionList.Count;
        public int LifeCount => QuestionsVaultConfig.LifeQuestionConfig.QuestionList.Count;
        public int DreamCount => QuestionsVaultConfig.DreamsQuestionConfig.QuestionList.Count;
        public int WhoCount => QuestionsVaultConfig.ChurchQuestionConfig.QuestionList.Count;

        public MainMenuModel(DIContainer sceneContainer)
        {
            var dataProvider = sceneContainer.Resolve<DataProvider>();

            QuestionsVaultConfig = sceneContainer.Resolve<ScreenVaultConfig>();
            FavouriteQuestionsProxy = dataProvider.FavouriteQuestionsDataProxy;
        }
    }
}
