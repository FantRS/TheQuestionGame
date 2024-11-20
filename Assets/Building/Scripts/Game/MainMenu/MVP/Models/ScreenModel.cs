using MainSpace.Configs;
using R3;
using System.Collections.Generic;

namespace MainSpace.MainMenu.Models
{
    public sealed class ScreenModel
    {
        public readonly ScreenConfig Config;

        public readonly ReactiveProperty<int> CurrentIdx;
        public readonly List<string> Questions;

        public readonly CompositeDisposable Subscriptions;

        public ScreenModel(ScreenConfig config)
        {
            Config = config;

            Questions = new List<string>(config.QuestionList);
            CurrentIdx = new ReactiveProperty<int>(0);

            Subscriptions = new CompositeDisposable();
        }
    }
}
