using MainSpace.MainMenu.Views;
using UnityEngine;

namespace MainSpace.MainMenu.Root
{
    public sealed class ScreenViewStorage : MonoBehaviour
    {
        [SerializeField] private ScreenView _screenView;
        [SerializeField] private SwipeCardView _swipeCardView;
        [SerializeField] private QuestionListView _questionListView;

        public ScreenView ScreenView => _screenView;
        public SwipeCardView SwipeCardView => _swipeCardView;
        public QuestionListView QuestionListView => _questionListView;
    }
}
