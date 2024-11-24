using System.IO;

namespace MainSpace.Data.Root
{
    public sealed class DataProvider
    {
        private const string FAV_QUESTIONS_DATA_KEY = nameof(FAV_QUESTIONS_DATA_KEY);

        private FavouriteQuestionsData _favouriteQuestionsData;

        public FavouriteQuestionsDataProxy FavouriteQuestionsDataProxy { get; private set; }

        public void SaveFavouriteQuestionData()
        {
            StorageService.Save(FAV_QUESTIONS_DATA_KEY, _favouriteQuestionsData);
        }

        public void LoadFavouriteQuestionData()
        {
            try
            {
                _favouriteQuestionsData = StorageService.Load<FavouriteQuestionsData>(FAV_QUESTIONS_DATA_KEY);
                FavouriteQuestionsDataProxy = new FavouriteQuestionsDataProxy(_favouriteQuestionsData);
            }
            catch (FileNotFoundException)
            {
                _favouriteQuestionsData = new FavouriteQuestionsData();
                FavouriteQuestionsDataProxy = new FavouriteQuestionsDataProxy(_favouriteQuestionsData);

                SaveFavouriteQuestionData();
            }
        }

        public void ResetFavouriteQuestionData()
        {
            _favouriteQuestionsData = new FavouriteQuestionsData();
            FavouriteQuestionsDataProxy = new FavouriteQuestionsDataProxy(_favouriteQuestionsData);
        }
    }
}
