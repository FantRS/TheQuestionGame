using BaCon;
using MainSpace.Data;
using MainSpace.Data.Root;
using R3;

namespace MainSpace.MainMenu.Presenters
{
    public sealed class SettingsModel
    {
        public readonly string SHUFFLE_BUTTON_STATE_TRUE = "Тасовать карты";
        public readonly string SHUFFLE_BUTTON_STATE_FALSE = "Не тасовать карты";

        public readonly FavouriteQuestionsDataProxy FafouriteListData;
        public readonly SettingsDataProxy SettingsData;

        public readonly CompositeDisposable CompositeDisposables;

        public SettingsModel(DIContainer sceneContainer)
        {
            var dataProvider = sceneContainer.Resolve<DataProvider>();

            FafouriteListData = dataProvider.FavouriteQuestionsDataProxy;
            SettingsData = dataProvider.SettingsDataProxy;

            CompositeDisposables = new CompositeDisposable();
        }
    }
}
