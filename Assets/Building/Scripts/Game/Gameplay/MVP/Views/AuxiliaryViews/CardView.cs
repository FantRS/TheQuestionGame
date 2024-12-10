using DG.Tweening;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MainSpace.MainMenu.Views
{
    public sealed class CardView : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
    {
        [Header("UI Elements")]
        [SerializeField] private TMP_Text _questionText;
        [SerializeField] private Text _categoryText;
        [SerializeField] private Text _cardIndex;
        [SerializeField] private Image _cardImage;
        [SerializeField] private Button _starButton;

        [Header("Hiden elements")]
        [SerializeField] private Text _toNextText;
        [SerializeField] private Text _toPrevText;

        [Header("Other elements")]
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private CanvasGroup _cardSelection;
        [SerializeField] private CanvasGroup _insideSelection;

        [Header("Animation properties")]
        [SerializeField] private float AnimationSpeed;
        [SerializeField] private float AnimationDuration;

        [Header("Sprites")]
        [SerializeField] private Image _starImage;
        [SerializeField] private Sprite _starNotFilledSprite;
        [SerializeField] private Sprite _starFilledSprite;

        // getters
        public TMP_Text QuestionText => _questionText;
        public Text CategoryText => _categoryText;
        public Text CardIndex => _cardIndex;
        public Image CardImage => _cardImage;
        public Button StarButton => _starButton;

        public Text ToNextText => _toNextText;
        public Text ToPrevText => _toPrevText;

        // private variables
        private readonly float _dropRadius = 75;
        private Vector2 _startPosition;
        private Vector2 _endPosition;
        private Canvas _canvas;

        // events
        public readonly Subject<bool> OnEndDragEvent = new();

        private void Start()
        {
            _cardSelection.blocksRaycasts = true;
            _insideSelection.DOFade(1, AnimationDuration / 4).SetLink(this.gameObject);

            Color alphaColor = _toNextText.color;
            alphaColor.a = 0;
            _toNextText.color = alphaColor;
            _toPrevText.color = alphaColor;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _startPosition = eventData.position;
            _canvas = GetComponentInParent<Canvas>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;

            float distance = eventData.position.x - _startPosition.x;
            float factor = Screen.width / 4;
            float targetFade = Mathf.Abs(distance) / factor;

            if (distance > 0)
            {
                _toNextText.DOFade(targetFade, 0);
                _toPrevText.DOFade(0, 0);
            }
            else
            {
                _toPrevText.DOFade(targetFade, 0);
                _toNextText.DOFade(0, 0);
            }

            _categoryText.DOFade(1 - targetFade, 0);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _endPosition = eventData.position;
            var swipeDistance = _endPosition - _startPosition;

            if (Mathf.Abs(swipeDistance.x) < _dropRadius && Mathf.Abs(swipeDistance.y) < _dropRadius)
            {
                transform.localPosition = Vector2.zero;

                _toNextText.DOFade(0, 0);
                _toPrevText.DOFade(0, 0);
                _categoryText.DOFade(1, 0);

                return;
            }

            _cardSelection.blocksRaycasts = false;

            Vector2 direction;
            bool isNextDirection;

            if (_startPosition.x > _endPosition.x)
            {
                direction = Vector2.left * AnimationSpeed;
                isNextDirection = false;
            }
            else
            {
                direction = Vector2.right * AnimationSpeed;
                isNextDirection = true;
            }

            OnEndDragEvent.OnNext(isNextDirection);

            _cardSelection.DOFade(0, AnimationDuration).SetLink(this.gameObject);

            transform
                .DOLocalMove(direction, AnimationDuration)
                .SetEase(Ease.OutQuart)
                .SetLink(this.gameObject)
                .OnComplete(() =>
                {
                    Destroy(this.gameObject);
                });
        }

        public void SetFilledStarButton()
        {
            _starImage.sprite = _starFilledSprite;
        }

        public void SetNotFilledStarButton()
        {
            _starImage.sprite = _starNotFilledSprite;
        }
    }
}
