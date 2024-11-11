using UnityEngine;

namespace MainSpace.Configs
{
    [CreateAssetMenu(fileName ="QuestionVault", menuName ="Configs/QuestionVault")]
    public sealed class QuestionVaultConfig : ScriptableObject
    {
        [SerializeField] private QuestionsConfig _forGirlsQuestionConfig;
        [SerializeField] private QuestionsConfig _forBoysQuestionConfig;
        [SerializeField] private QuestionsConfig _forLoversQuestionConfig;
        [SerializeField] private QuestionsConfig _funnyQuestionConfig;
        [SerializeField] private QuestionsConfig _artistsQuestionsConfig;
        [SerializeField] private QuestionsConfig _lifeQuestionsConfig;
        [SerializeField] private QuestionsConfig _dreamsQuestionsConfig;
        [SerializeField] private QuestionsConfig _churchQuestionsConfig;

        public QuestionsConfig ForGirlsQuestionConfig => _forGirlsQuestionConfig;
        public QuestionsConfig ForBoysQuestionConfig => _forBoysQuestionConfig;
        public QuestionsConfig ForLoversQuestionConfig => _forLoversQuestionConfig;
        public QuestionsConfig FunnyQuestionConfig => _funnyQuestionConfig;
        public QuestionsConfig ArtistsQuestionConfig => _artistsQuestionsConfig;
        public QuestionsConfig LifeQuestionConfig => _lifeQuestionsConfig;
        public QuestionsConfig DreamsQuestionConfig => _dreamsQuestionsConfig;
        public QuestionsConfig ChurchQuestionConfig => _churchQuestionsConfig;
    }
}
