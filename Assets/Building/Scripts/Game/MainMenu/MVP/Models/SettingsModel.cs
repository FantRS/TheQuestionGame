using BaCon;
using MainSpace.Data;
using MainSpace.Data.Root;

namespace MainSpace.MainMenu.Presenters
{
    public sealed class SettingsModel
    {
        public readonly FavouriteQuestionsDataProxy FafouriteListData;
        public readonly SettingsDataProxy SettingsData;

        public SettingsModel(DIContainer sceneContainer)
        {
            var dataProvider = sceneContainer.Resolve<DataProvider>();

            FafouriteListData = dataProvider.FavouriteQuestionsDataProxy;
            SettingsData = dataProvider.SettingsDataProxy;
        }
    }
}
