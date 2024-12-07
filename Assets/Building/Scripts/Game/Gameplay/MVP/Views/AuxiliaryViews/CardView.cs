using DG.Tweening;
using R3;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MainSpace.MainMenu.Views
{
    public sealed class CardView : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
    {
        [Header("UI Elements")]
        [SerializeField] private Text _questionText;
        [SerializeField] private Text _categoryText;
        [SerializeField] private Text _cardIndex;
        [SerializeField] private Image _cardImage;
        [SerializeField] private Button _starButton;

        [SerializeField] private CanvasGroup _canvasGroup;

        [Header("Animation properties")]
        [SerializeField] private float AnimationSpeed;
        [SerializeField] private float AnimationDuration;

        [Header("Sprites")]
        [SerializeField] private Image _starImage;
        [SerializeField] private Sprite _starNotFilledSprite;
        [SerializeField] private Sprite _starFilledSprite;

        // getters
        public Text QuestionText => _questionText;
        public Text CategoryText => _categoryText;
        public Text CardIndex => _cardIndex;
        public Image CardImage => _cardImage;
        public Button StarButton => _starButton;
        public CanvasGroup CanvasGroup => _canvasGroup;

        // private variables
        private Vector2 _startPosition;
        private Vector2 _endPosition;
        
        // events
        public readonly Subject<bool> OnEndDragEvent = new();

        public void OnBeginDrag(PointerEventData eventData)
        {
            _startPosition = eventData.position;
        }

        public void OnDrag(PointerEventData eventData) { }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = false;

            _endPosition = eventData.position;
            Vector2 direction;
            bool isNextDirection;

            if (_startPosition.x > _endPosition.x)
            {
                Debug.Log("Next");

                direction = Vector2.left * AnimationSpeed;
                isNextDirection = true;
            }
            else
            {
                Debug.Log("Prev");

                direction = Vector2.right * AnimationSpeed;
                isNextDirection = false;
            }

            OnEndDragEvent.OnNext(isNextDirection);

            _canvasGroup.DOFade(0, AnimationDuration);
            transform
                .DOLocalMove(direction, AnimationDuration)
                .SetEase(Ease.OutQuart)
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
