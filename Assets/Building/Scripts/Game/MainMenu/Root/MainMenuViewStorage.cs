using MainSpace.MainMenu.Views;
using UnityEngine;

namespace MainSpace.MainMenu.Root
{
    public sealed class MainMenuViewStorage : MonoBehaviour
    {
        [SerializeField] private MainMenuView _mainMenuView;

        public MainMenuView MainMenuView => _mainMenuView;
    }
}
