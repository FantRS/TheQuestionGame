using UnityEngine;

namespace MainSpace.Root.UI
{
    public sealed class LoadingCircle : MonoBehaviour
    {
        private void Update()
        {
            transform.Rotate(-Vector3.forward * 2);
        }
    }
}
