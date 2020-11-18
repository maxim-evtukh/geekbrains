using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelLoadingController : MonoBehaviour
{
    #region Fields

    [SerializeField] private string _nextLevelName;

    #endregion


    #region UnityMethods

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadSceneRoutine());
        }
    }

    #endregion


    #region Methods

    private IEnumerator LoadSceneRoutine()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_nextLevelName, LoadSceneMode.Single);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    #endregion

}
