using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _player;

    #endregion


    #region PrivateData

    private Menu.Mode _menuMode = Menu.Mode.Pause;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _player.GetComponent<PlayerController>().Caught = OnPlayerCaught;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !SceneManager.GetSceneByName("Menu").isLoaded)
        {
            Menu.CurrentMode = _menuMode;

            SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        }
    }

    #endregion


    #region Methods

    public void GameFinished()
    {
        _menuMode = Menu.Mode.Menu;
    }

    private void OnPlayerCaught()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #endregion

}
