using UnityEngine;

namespace MainSpace.Configs
{
    [CreateAssetMenu(fileName = "LocaleMap", menuName = "Configs/LocaleMap")]
    public sealed class LocaleMap : ScriptableObject
    {
        [SerializeField] private ScreenVaultConfig _enVaultConfig;  // English
        [SerializeField] private ScreenVaultConfig _ruVaultConfig;  // Russian
        [SerializeField] private ScreenVaultConfig _uaVaultConfig;  // Ukrainian

        public ScreenVaultConfig GetVaultConfigByLanguage(int localeId)
        {
            switch (localeId)
            {
                case 0: return _enVaultConfig;
                case 1: return _ruVaultConfig;
                case 2: return _uaVaultConfig;
                default: throw new System.Exception("Non-existent language config");
            }
        }
    }
}
