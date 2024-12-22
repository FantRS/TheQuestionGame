using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace MainSpace.MainMenu.Views
{
    public sealed class TabControlView : MonoBehaviour
    {
        [SerializeField] private float FadeTime;

        [Header("Categories")]
        [SerializeField] private Button _toCategoryButton;
        [SerializeField] private Button _categoryBackButton;

        [Header("Settings")]
        [SerializeField] private Button _toSettingsButton;
        [SerializeField] private Button _settingsBackButton;

        [Header("AboutGame")]
        [SerializeField] private Button _toAboutGameButton;
        [SerializeField] private Button _aboutGameBackButton;

        [Header("Donate")]
        [SerializeField] private Button _toDonateButton;
        [SerializeField] private Button _donateBackButton;

        [Header("Groups")]
        [SerializeField] private CanvasGroup _mainMenuGroup;
        [SerializeField] private CanvasGroup _categoryGroup;
        [SerializeField] private CanvasGroup _settingsGroup;
        [SerializeField] private CanvasGroup _aboutGameGroup;
        [SerializeField] private CanvasGroup _donateGroup;

        private void Start ()
        {
            _toCategoryButton.onClick.AddListener(() =>
            {
                DisableGroup(_mainMenuGroup);
                EnableGroup(_categoryGroup);
            });

            _categoryBackButton.onClick.AddListener(() =>
            {
                DisableGroup(_categoryGroup);
                EnableGroup(_mainMenuGroup);
            });

            _toSettingsButton.onClick.AddListener(() =>
            {
                DisableGroup(_mainMenuGroup);
                EnableGroup(_settingsGroup);
            });

            _settingsBackButton.onClick.AddListener(() =>
            {
                DisableGroup(_settingsGroup);
                EnableGroup(_mainMenuGroup);
            });

            _toAboutGameButton.onClick.AddListener(() =>
            {
                DisableGroup(_mainMenuGroup);
                EnableGroup(_aboutGameGroup);
            });

            _aboutGameBackButton.onClick.AddListener(() =>
            {
                DisableGroup(_aboutGameGroup);
                EnableGroup(_mainMenuGroup);
            });

            _toDonateButton.onClick.AddListener(() =>
            {
                DisableGroup(_mainMenuGroup);
                EnableGroup(_donateGroup);
            });

            _donateBackButton.onClick.AddListener(() =>
            {
                DisableGroup(_donateGroup);
                EnableGroup(_mainMenuGroup);
            });
        }

        private void DisableGroup(CanvasGroup group)
        {
            group.blocksRaycasts = false;
            group.interactable = false;
            group.DOFade(0, FadeTime);
        }

        private void EnableGroup(CanvasGroup group)
        {
            group.blocksRaycasts = true;
            group.interactable = true;
            group.DOFade(1, FadeTime);
        }
    }
}
