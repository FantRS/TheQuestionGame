using UnityEngine;

namespace MainSpace.Utils
{
    public sealed class Coroutines : MonoBehaviour
    {
        public static Coroutines Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                return;
            }

            Destroy(this.gameObject);
        }
    }
}
