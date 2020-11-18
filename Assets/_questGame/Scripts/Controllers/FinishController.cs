using UnityEngine;

public class FinishController : MonoBehaviour
{
    #region Fields

    [SerializeField] private Canvas _imageCanvas;
    [SerializeField] private SceneController _sceneController;

    #endregion


    #region UnityMethods

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _sceneController.GameFinished();
            _imageCanvas.gameObject.SetActive(true);
        }
    }

    #endregion

}
