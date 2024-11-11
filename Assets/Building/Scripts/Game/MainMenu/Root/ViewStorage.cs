using MainSpace.MainMenu.Views;
using UnityEngine;

namespace MainSpace.MainMenu.Root
{
    public sealed class ViewStorage : MonoBehaviour
    {
        [SerializeField] private MainMenuView _mainMenuView;
        [SerializeField] private ScreenView _forGirlsScreen;
        [SerializeField] private ScreenView _forBoysScreen;
        [SerializeField] private ScreenView _forLoverScreen;
        [SerializeField] private ScreenView _funnyScreen;
        [SerializeField] private ScreenView _atristsScreen;
        [SerializeField] private ScreenView _lifeScreen;
        [SerializeField] private ScreenView _dreamScreen;
        [SerializeField] private ScreenView _churchScreen;

        public MainMenuView MainMenuView => _mainMenuView;
        public ScreenView ForGirlsScreen => _forGirlsScreen;
        public ScreenView ForBoysScreen => _forBoysScreen;
        public ScreenView ForLoverScreen => _forLoverScreen;
        public ScreenView FunnyScreen => _funnyScreen;
        public ScreenView ArtistsScreen => _atristsScreen;
        public ScreenView LifeScreen => _lifeScreen;
        public ScreenView DreamScreen => _dreamScreen;
        public ScreenView ChurchScreen => _churchScreen;
    }
}
