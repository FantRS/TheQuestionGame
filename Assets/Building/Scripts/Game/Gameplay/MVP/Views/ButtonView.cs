using UnityEngine;
using UnityEngine.UI;

namespace MainSpace.MainMenu.Views
{
    public sealed class ButtonView : MonoBehaviour
    {
        [SerializeField] private Button _currentButton;
        [SerializeField] private Text _currentText;
        [SerializeField] private Image _currentImage;

        public Button CurrentButton => _currentButton;
        public Text CurrentText => _currentText;
        public Image CurrentImage => _currentImage;
    }
}
