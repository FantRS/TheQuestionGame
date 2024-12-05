using R3;

namespace MainSpace.Data
{
    public sealed class SettingsDataProxy
    {
        private readonly SettingsData _originData;

        public ReactiveProperty<bool> IsShuffeMode;

        public SettingsDataProxy(SettingsData originData)
        {
            _originData = originData;

            IsShuffeMode = new ReactiveProperty<bool>(_originData.IsShuffleMode);

            IsShuffeMode.Subscribe((value) =>
            {
                _originData.IsShuffleMode = value;
            });
        }
    }
}
