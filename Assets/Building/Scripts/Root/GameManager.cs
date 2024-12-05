using MainSpace.Data.Root;
using UnityEngine;

namespace MainSpace.Root
{
    public sealed class GameManager : MonoBehaviour
    {
        private DataProvider _dataProvider;

        public void SetDataProvider(DataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        private void SaveGameStates()
        {
            _dataProvider.SaveFavouriteQuestionData();
            _dataProvider.SaveSettingsData();
        }

#if UNITY_EDITOR
        private void OnApplicationQuit()
        {
            SaveGameStates();
        }
#elif PLATFORM_ANDROID
private void OnApplicationFocus()
{
    SaveGameStates();
}
#endif

    }
}
