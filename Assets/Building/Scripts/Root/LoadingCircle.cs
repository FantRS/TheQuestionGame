using UnityEngine;

namespace Assets.Building.Scripts.Root
{
    public class LoadingCircle : MonoBehaviour
    {
        private void Update()
        {
            transform.Rotate(-Vector3.forward * 2);
        }
    }
}
