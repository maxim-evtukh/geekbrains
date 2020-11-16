using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _player;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _player.GetComponent<PlayerController>().Caught = OnPlayerCaught;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    #endregion


    #region Methods

    private void OnPlayerCaught()
    {
        SceneManager.LoadScene(0);
    }

    #endregion

}
