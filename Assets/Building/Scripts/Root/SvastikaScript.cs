using UnityEngine;

namespace Assets.Building.Scripts.Root
{
    public class SvastikaScript : MonoBehaviour
    {
        private void Update()
        {
            transform.Rotate(Vector3.forward);
        }
    }
}
