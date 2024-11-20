using MainSpace.Configs;
using System.Collections.Generic;

namespace MainSpace.MainMenu.Models
{
    public sealed class QuestionListModel
    {
        public readonly List<string> Questions;

        public QuestionListModel(ScreenConfig config)
        {
            Questions = new List<string>(config.QuestionList);
        }
    }
}
