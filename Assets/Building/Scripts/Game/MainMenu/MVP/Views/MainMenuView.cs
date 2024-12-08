using MainSpace.Configs;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace MainSpace.MainMenu.Views
{
    public sealed class MainMenuView : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button _favouriteQuestionsButton;
        [SerializeField] private Button _forGirlsQuestionsButton;
        [SerializeField] private Button _forBoysQuestionsButton;
        [SerializeField] private Button _forLoverQuestionsButton;
        [SerializeField] private Button _funnyQuestionsButton;
        [SerializeField] private Button _artistsQuestionsButton;
        [SerializeField] private Button _lifeQuestionsButton;
        [SerializeField] private Button _dreamQuestionsButton;

        [Header("Questions count texts")]
        [SerializeField] private Text _favouriteQuestionsCount;
        [SerializeField] private Text _forGirlsQuestionsCount;
        [SerializeField] private Text _forBoysQuestionsCount;
        [SerializeField] private Text _forLoverQuestionsCount;
        [SerializeField] private Text _funnyQuestionsCount;
        [SerializeField] private Text _artistsQuestionsCount;
        [SerializeField] private Text _lifeQuestionsCount;
        [SerializeField] private Text _dreamQuestionsCount;

        // events
        public readonly Subject<Unit> FavouriteQuestionsButtonClickEvent = new();
        public readonly Subject<Unit> OnForGirlsQuestionsButtonClickEvent = new();
        public readonly Subject<Unit> OnForBoysQuestionsButtonClickEvent = new();
        public readonly Subject<Unit> OnForLoversQuestionsButtonClickEvent = new();
        public readonly Subject<Unit> OnFunnyQuestionsButtonClickEvent = new();
        public readonly Subject<Unit> OnArtistQuestionsButtonClickEvent = new();
        public readonly Subject<Unit> OnLifeQuestionsButtonClickEvent = new();
        public readonly Subject<Unit> OnDreamQuestionsButtonClickEvent = new();

        public Subject<ScreenConfig> SceneTransitionSignal { get; private set; }

        public Subject<Unit> DisposeEvent = new();

        private void Start()
        {
            _favouriteQuestionsButton.onClick.AddListener(() =>
            {
                FavouriteQuestionsButtonClickEvent?.OnNext(Unit.Default);
            });

            _forGirlsQuestionsButton.onClick.AddListener(() =>
            {
                OnForGirlsQuestionsButtonClickEvent?.OnNext(Unit.Default);
            });

            _forBoysQuestionsButton.onClick.AddListener(() =>
            {
                OnForBoysQuestionsButtonClickEvent?.OnNext(Unit.Default);
            });

            _forLoverQuestionsButton.onClick.AddListener(() =>
            {
                OnForLoversQuestionsButtonClickEvent?.OnNext(Unit.Default);
            });

            _funnyQuestionsButton.onClick.AddListener(() =>
            {
                OnFunnyQuestionsButtonClickEvent?.OnNext(Unit.Default);
            });

            _artistsQuestionsButton.onClick.AddListener(() =>
            {
                OnArtistQuestionsButtonClickEvent?.OnNext(Unit.Default);
            });

            _lifeQuestionsButton.onClick.AddListener(() =>
            {
                OnLifeQuestionsButtonClickEvent?.OnNext(Unit.Default);
            });

            _dreamQuestionsButton.onClick.AddListener(() =>
            {
                OnDreamQuestionsButtonClickEvent?.OnNext(Unit.Default);
            });
        }

        private void OnDestroy()
        {
            DisposeEvent.OnNext(Unit.Default);
        }

        public void BindSceneTransitionSignal(Subject<ScreenConfig> subject)
        {
            SceneTransitionSignal = subject;
        }

        public void DisableFavouriteButton()
        {
            _favouriteQuestionsButton.interactable = false;
        }

        public void ShowGirlsQuestionsCount(int count)
        {
            _forGirlsQuestionsCount.text = count.ToString();
        }

        public void ShowBoysQuestionsCount(int count)
        {
            _forBoysQuestionsCount.text = count.ToString();
        }

        public void ShowLoversQuestionsCount(int count)
        {
            _forLoverQuestionsCount.text = count.ToString();
        }

        public void ShowFunnyQuestionsCount(int count)
        {
            _funnyQuestionsCount.text = count.ToString();
        }

        public void ShowArtistQuestionsCount(int count)
        {
            _artistsQuestionsCount.text = count.ToString();
        }

        public void ShowLifeQuestionsCount(int count)
        {
            _lifeQuestionsCount.text = count.ToString();
        }

        public void ShowDreamQuestionsCount(int count)
        {
            _dreamQuestionsCount.text = count.ToString();
        }

        public void ShowFavouriteQuestionsCount(int count)
        {
            _favouriteQuestionsCount.text = count.ToString();
        }
    }
}
