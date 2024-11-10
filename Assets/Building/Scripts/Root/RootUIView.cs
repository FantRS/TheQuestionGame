using UnityEngine;

namespace MainSpace.Root
{
    public sealed class RootUIView : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingScreen;
        [SerializeField] private GameObject _sceneUIContainer;

        public void AttachSceneUI(GameObject sceneUI)
        {
            ClearSceneUI(_sceneUIContainer);

            sceneUI.transform.SetParent(_sceneUIContainer.transform, false);
        }

        private void ClearSceneUI(GameObject sceneContainer)
        {
            foreach (Transform item in sceneContainer.transform)
            {
                Destroy(item.gameObject);
            }
        }

        public void ShowLoadingScreen()
        {
            _loadingScreen.SetActive(true);
        }

        public void HideLoadingScreen()
        {
            _loadingScreen.SetActive(false);
        }
    }
}
