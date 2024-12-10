using System;

namespace MainSpace.Data
{
    [Serializable]
    public sealed class SettingsData
    {
        public bool IsShuffleMode;
        public int LanguageID;

        public SettingsData()
        {
            IsShuffleMode = false;
            LanguageID = 0;
        }
    }
}
