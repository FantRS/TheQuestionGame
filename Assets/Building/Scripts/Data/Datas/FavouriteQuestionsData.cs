using MainSpace.DataStructures;
using System;
using System.Collections.Generic;

namespace MainSpace.Data
{
    [Serializable]
    public sealed class FavouriteQuestionsData
    {
        public List<Question> QuestionList;

        public FavouriteQuestionsData()
        {
            QuestionList = new List<Question>();
        }
    }
}
