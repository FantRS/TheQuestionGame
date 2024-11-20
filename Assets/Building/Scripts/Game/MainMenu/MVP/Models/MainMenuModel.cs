using MainSpace.Configs;

namespace MainSpace.MainMenu.Models
{
    public sealed class MainMenuModel
    {
        public readonly ScreenVaultConfig QuestionsConfig;

        public int GirlsQuestions => QuestionsConfig.ForGirlsQuestionConfig.QuestionList.Count;
        public int BoysQuestions => QuestionsConfig.ForBoysQuestionConfig.QuestionList.Count;
        public int LoverQuestions => QuestionsConfig.ForLoversQuestionConfig.QuestionList.Count;
        public int FunnyQuestions => QuestionsConfig.FunnyQuestionConfig.QuestionList.Count;
        public int ArtQuestions => QuestionsConfig.ArtistsQuestionConfig.QuestionList.Count;
        public int LifeQuestions => QuestionsConfig.LifeQuestionConfig.QuestionList.Count;
        public int DreamQuestions => QuestionsConfig.DreamsQuestionConfig.QuestionList.Count;
        public int ChurchQuestions => QuestionsConfig.ChurchQuestionConfig.QuestionList.Count;

        public MainMenuModel(ScreenVaultConfig vaultConfig)
        {
            QuestionsConfig = vaultConfig;
        }
    }
}
