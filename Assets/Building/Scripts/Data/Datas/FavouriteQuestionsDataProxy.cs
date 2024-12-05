using MainSpace.DataStructures;
using ObservableCollections;
using R3;

namespace MainSpace.Data
{
    public sealed class FavouriteQuestionsDataProxy
    {
        private readonly FavouriteQuestionsData _originData;

        public readonly ObservableList<Question> QuestionsList;

        public FavouriteQuestionsDataProxy(FavouriteQuestionsData originData)
        {
            _originData = originData;

            QuestionsList = new ObservableList<Question>(_originData.QuestionList);

            QuestionsList.ObserveAdd().Subscribe((collectionValue) => _originData.QuestionList.Add(collectionValue.Value));
            QuestionsList.ObserveRemove().Subscribe((collectionValue) => _originData.QuestionList.Remove(collectionValue.Value));

            QuestionsList.ObserveClear().Subscribe(_ => _originData.QuestionList.Clear());
        }
    }
}
