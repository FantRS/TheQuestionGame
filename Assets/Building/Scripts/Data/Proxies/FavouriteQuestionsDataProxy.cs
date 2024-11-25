using MainSpace.DataStructures;
using System.Collections.Generic;

namespace MainSpace.Data
{
    public sealed class FavouriteQuestionsDataProxy
    {
        private readonly FavouriteQuestionsData _originData;

        public readonly List<Question> QuestionsList;

        public FavouriteQuestionsDataProxy(FavouriteQuestionsData originData)
        {
            _originData = originData;

            QuestionsList = _originData.QuestionList;
        }
    }
}
