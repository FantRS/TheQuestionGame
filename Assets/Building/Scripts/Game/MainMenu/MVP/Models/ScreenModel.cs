using MainSpace.Configs;

namespace MainSpace.MainMenu.Models
{
    public sealed class ScreenModel
    {
        public QuestionsConfig Config { get; private set; }

        public ScreenModel(QuestionsConfig config)
        {
            Config = config;
        }
    }
}
