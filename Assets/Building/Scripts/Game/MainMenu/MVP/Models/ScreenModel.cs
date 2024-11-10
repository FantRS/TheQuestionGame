using MainSpace.Configs;
using R3;
using System.Collections.Generic;

namespace MainSpace.MainMenu.Models
{
    public sealed class ScreenModel
    {
        public readonly ReactiveProperty<int> CurrentIdx;
        public readonly List<string> Questions;

        public ScreenModel(QuestionsConfig config)
        {
            Questions = new List<string>(config.QuestionList);
            CurrentIdx = new ReactiveProperty<int>();
        }
    }
}
