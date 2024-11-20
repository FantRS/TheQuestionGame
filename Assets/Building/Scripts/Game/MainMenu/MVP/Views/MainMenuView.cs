using MainSpace.Configs;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace MainSpace.MainMenu.Views
{
    public sealed class MainMenuView : MonoBehaviour
    {
        [Header("BUTTONS")]
        [SerializeField] private Button _forGirlsQuestionsButton;
        [SerializeField] private Button _forBoysQuestionsButton;
        [SerializeField] private Button _forLoverQuestionsButton;
        [SerializeField] private Button _funnyQuestionsButton;
        [SerializeField] private Button _artistsQuestionsButton;
        [SerializeField] private Button _lifeQuestionsButton;
        [SerializeField] private Button _dreamQuestionsButton;
        [SerializeField] private Button _churchQuestionsButton;

        [Header("Questions count texts")]
        [SerializeField] private Text _forGirlsQuestionsCount;
        [SerializeField] private Text _forBoysQuestionsCount;
        [SerializeField] private Text _forLoverQuestionsCount;
        [SerializeField] private Text _funnyQuestionsCount;
        [SerializeField] private Text _artistsQuestionsCount;
        [SerializeField] private Text _lifeQuestionsCount;
        [SerializeField] private Text _dreamQuestionsCount;
        [SerializeField] private Text _churchQuestionsCount;

        // events
        public Subject<Unit> OnForGirlsQuestionsButtonClickEvent = new();
        public Subject<Unit> OnForBoysQuestionsButtonClickEvent = new();
        public Subject<Unit> OnForLoversQuestionsButtonClickEvent = new();
        public Subject<Unit> OnFunnyQuestionsButtonClickEvent = new();
        public Subject<Unit> OnArtistQuestionsButtonClickEvent = new();
        public Subject<Unit> OnLifeQuestionsButtonClickEvent = new();
        public Subject<Unit> OnDreamQuestionsButtonClickEvent = new();
        public Subject<Unit> OnChurchQuestionsButtonClickEvent = new();
        public Subject<ScreenConfig> SceneTransitionSignal { get; private set; }

        private void Start()
        {
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

            _churchQuestionsButton.onClick.AddListener(() =>
            {
                OnChurchQuestionsButtonClickEvent?.OnNext(Unit.Default);
            });
        }

        public void BindSceneTransitionSignal(Subject<ScreenConfig> subject)
        {
            SceneTransitionSignal = subject;
        }


        #region Change questions count

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

        public void ShowChurchQuestionsCount(int count)
        {
            _churchQuestionsCount.text = count.ToString();
        }

        #endregion
    }
}
