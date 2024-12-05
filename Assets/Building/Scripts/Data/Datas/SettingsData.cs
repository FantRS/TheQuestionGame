using System;

namespace MainSpace.Data
{
    [Serializable]
    public sealed class SettingsData
    {
        public bool IsShuffleMode;

        public SettingsData()
        {
            IsShuffleMode = false;
        }
    }
}
