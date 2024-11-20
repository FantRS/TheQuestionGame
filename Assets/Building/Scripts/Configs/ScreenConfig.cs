using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainSpace.Configs
{
    [CreateAssetMenu(fileName ="Questions", menuName ="Configs/Questions")]
    public class ScreenConfig : ScriptableObject
    {
        [SerializeField] private string _screenName;
        [SerializeField] private Sprite _background;
        [SerializeField] private Color _questionTextColor;
        [SerializeField, TextArea(2, 2)] private List<string> _questionList;

        public string ScreenName => _screenName;
        public Sprite Background => _background;
        public Color QuestionTextColor => _questionTextColor;
        public List<string> QuestionList => _questionList;
    }
}
