using UnityEngine;

namespace MainSpace.Configs
{
    [CreateAssetMenu(fileName ="QuestionVault", menuName ="Configs/QuestionVault")]
    public sealed class ScreenVaultConfig : ScriptableObject
    {
        [SerializeField] private ScreenConfig _favouriteConfig;

        [SerializeField] private ScreenConfig _forGirlsQuestionConfig;
        [SerializeField] private ScreenConfig _forBoysQuestionConfig;
        [SerializeField] private ScreenConfig _forLoversQuestionConfig;
        [SerializeField] private ScreenConfig _artistsQuestionsConfig;
        [SerializeField] private ScreenConfig _lifeQuestionsConfig;
        [SerializeField] private ScreenConfig _dreamsQuestionsConfig;
        [SerializeField] private ScreenConfig _familyQuestionsConfig;
        [SerializeField] private ScreenConfig _whichOfQuestionConfig;


        public ScreenConfig FavouriteConfig => _favouriteConfig;

        public ScreenConfig ForGirlsQuestionConfig => _forGirlsQuestionConfig;
        public ScreenConfig ForBoysQuestionConfig => _forBoysQuestionConfig;
        public ScreenConfig ForLoversQuestionConfig => _forLoversQuestionConfig;
        public ScreenConfig ArtistsQuestionConfig => _artistsQuestionsConfig;
        public ScreenConfig LifeQuestionConfig => _lifeQuestionsConfig;
        public ScreenConfig DreamsQuestionConfig => _dreamsQuestionsConfig;
        public ScreenConfig FamilyQuestionConfig => _familyQuestionsConfig;
        public ScreenConfig WhichOfQuestionConfig => _whichOfQuestionConfig;
    }
}
