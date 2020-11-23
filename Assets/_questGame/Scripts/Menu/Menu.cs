using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public enum Mode
    {
        Menu,
        Pause
    }

    #region Fields

    [SerializeField] Button _startButton;
    [SerializeField] Button _settingsButton;
    [SerializeField] Button _exitButton;
    [SerializeField] Image _background;

    [SerializeField] Camera _camera;

    #endregion


    #region Properties

    public static Mode CurrentMode { get; set; }

    #endregion


    #region UnityMethods

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartExecute);
        _settingsButton.onClick.AddListener(OnSettingsExecute);
        _exitButton.onClick.AddListener(OnExitExecute);
    }

    private void Start()
    {
        _camera.enabled = CurrentMode == Mode.Menu;

        _startButton.GetComponentInChildren<Text>().text = GetStartTitle();
        _background.color = GetBkgColor();
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartExecute);
        _settingsButton.onClick.RemoveListener(OnSettingsExecute);
        _exitButton.onClick.RemoveListener(OnExitExecute);
    }

    #endregion


    #region Methods

    private string GetStartTitle()
    {
        switch (CurrentMode)
        {
            case Mode.Menu:
                return "Начать игру";
            case Mode.Pause:
                return "Продолжить";
            default:
                return "";
        }
    }

    private Color GetBkgColor()
    {
        switch (CurrentMode)
        {
            case Mode.Menu:
                return Color.black;
            case Mode.Pause:
                return new Color(0.0f, 0.0f, 0.0f, 0.9f);
            default:
                return Color.black;
        }
    }

    private void OnStartExecute()
    {
        switch (CurrentMode)
        {
            case Mode.Menu:
                SceneManager.LoadScene("Level_1");
                break;
            case Mode.Pause:
                StartCoroutine(UnloadSceneRoutine());
                break;
            default:
                break;
        }
    }

    private IEnumerator UnloadSceneRoutine()
    {
        var asyncLoad = SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Menu"));

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private void OnExitExecute()
    {
        Application.Quit();
    }

    private void OnSettingsExecute()
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Additive);
    }

    #endregion

}
