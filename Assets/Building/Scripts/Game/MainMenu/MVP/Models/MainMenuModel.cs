using BaCon;
using MainSpace.Configs;
using MainSpace.MainMenu.Root;
using R3;

namespace MainSpace.MainMenu.Models
{
    public sealed class MainMenuModel
    {
        public readonly QuestionVaultConfig QuestionsConfig;
        public readonly ViewStorage ViewStorage;

        public MainMenuModel(DIContainer sceneContainer)
        {
            QuestionsConfig = sceneContainer.Resolve<QuestionVaultConfig>();
            ViewStorage = sceneContainer.Resolve<ViewStorage>();
        }
    }
}
