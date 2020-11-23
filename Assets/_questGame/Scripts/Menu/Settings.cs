using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    #region Fields

    [SerializeField] Button _backButton;

    #endregion


    #region UnityMethods

    private void OnEnable()
    {
        _backButton.onClick.AddListener(OnBackExecute);
    }
    private void OnDisable()
    {
        _backButton.onClick.RemoveListener(OnBackExecute);
    }

    #endregion


    #region Methods

    private void OnBackExecute()
    {
        StartCoroutine(UnloadSceneRoutine());
    }

    private IEnumerator UnloadSceneRoutine()
    {
        var asyncLoad = SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Settings"));

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }


    #endregion
}
