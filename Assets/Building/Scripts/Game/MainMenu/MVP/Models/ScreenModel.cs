using BaCon;
using MainSpace.Configs;
using MainSpace.Data;
using MainSpace.Data.Root;
using MainSpace.DataStructures;
using R3;
using System.Collections.Generic;

namespace MainSpace.MainMenu.Models
{
    public sealed class ScreenModel
    {
        public readonly ScreenConfig Config;
        public readonly FavouriteQuestionsDataProxy FavouriteDataProxy;

        public readonly List<string> ShuffledStringsList;
        public readonly List<Question> ShuffledQuestionsList;
        public readonly ReactiveProperty<int> CurrentIndex;

        public readonly CompositeDisposable Subscriptions;

        public ScreenModel(DIContainer sceneContainer)
        {
            var dataProvider = sceneContainer.Resolve<DataProvider>();

            Config = sceneContainer.Resolve<ScreenConfig>();
            FavouriteDataProxy = dataProvider.FavouriteQuestionsDataProxy;


            ShuffledStringsList = new List<string>(Config.QuestionList);
            ShuffledQuestionsList = new List<Question>();
            CurrentIndex = new ReactiveProperty<int>(0);

            Subscriptions = new CompositeDisposable();
        }
    }
}
