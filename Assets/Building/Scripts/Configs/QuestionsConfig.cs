using System.Collections.Generic;
using UnityEngine;

namespace MainSpace.Configs
{
    [CreateAssetMenu(fileName ="Questions", menuName ="Configs/Questions")]
    public class QuestionsConfig : ScriptableObject
    {
        [SerializeField, TextArea(2, 2)] private List<string> _questionList;

        public List<string> QuestionList => _questionList;
    }
}
