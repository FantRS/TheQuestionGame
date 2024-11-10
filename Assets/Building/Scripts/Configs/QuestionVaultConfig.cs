using UnityEngine;

namespace MainSpace.Configs
{
    [CreateAssetMenu(fileName ="QuestionVault", menuName ="Configs/QuestionVault")]
    public sealed class QuestionVaultConfig : ScriptableObject
    {
        [SerializeField] private QuestionsConfig _forGirlsQuestionConfig;
        [SerializeField] private QuestionsConfig _forBoysQuestionConfig;

        public QuestionsConfig ForGirlsQuestionConfig => _forGirlsQuestionConfig;
        public QuestionsConfig ForBoysQuestionConfig => _forBoysQuestionConfig;
    }
}
