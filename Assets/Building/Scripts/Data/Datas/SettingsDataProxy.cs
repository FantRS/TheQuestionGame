using R3;

namespace MainSpace.Data
{
    public sealed class SettingsDataProxy
    {
        private readonly SettingsData _originData;

        public ReactiveProperty<bool> IsShuffeMode;
        public ReactiveProperty<int> LanguageID;

        public SettingsDataProxy(SettingsData originData)
        {
            _originData = originData;

            IsShuffeMode = new ReactiveProperty<bool>(_originData.IsShuffleMode);
            LanguageID = new ReactiveProperty<int>(_originData.LanguageID);

            IsShuffeMode.Subscribe((value) => _originData.IsShuffleMode = value);
            LanguageID.Subscribe((value) => _originData.LanguageID = value);
        }
    }
}
