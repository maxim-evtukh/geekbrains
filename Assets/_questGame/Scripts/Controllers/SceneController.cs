using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private void Start()
    {
        _player.GetComponent<DeactivationController>().onDisable = OnPlayerCaught;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnPlayerCaught(int instanceID)
    {
        SceneManager.LoadScene(0);
    }

}
