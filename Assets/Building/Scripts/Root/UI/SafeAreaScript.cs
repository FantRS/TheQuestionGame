using UnityEngine;

namespace MainSpace.Root.UI
{
    public sealed class SafeAreaScript : MonoBehaviour
    {
        private void Awake()
        {
            UpdateAnchors();
        }

        private void UpdateAnchors()
        {
            var safeAreaRect = Screen.safeArea;
            var rectTransform = this.GetComponent<RectTransform>();

            var anchorMin = safeAreaRect.position;
            var anchorMax = safeAreaRect.position + safeAreaRect.size;

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            rectTransform.anchorMin = anchorMin;
            rectTransform.anchorMax = anchorMax;
        }
    }
}
