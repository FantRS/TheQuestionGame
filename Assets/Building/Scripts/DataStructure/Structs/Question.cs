using System;

namespace MainSpace.DataStructures
{
    [Serializable]
    public struct Question
    {
        public int Index;
        public Category Category;

        public Question(int index, Category category)
        {
            Index = index;
            Category = category;
        }
    }
}
