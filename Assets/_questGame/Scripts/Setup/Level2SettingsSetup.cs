using UnityEngine;

public class Level2SettingsSetup : MonoBehaviour
{
    #region Fields

    [SerializeField] private PlayerController _playerController;

    #endregion


    #region UnityMethods

    void Start()
    {
        _playerController.UnlockGun();
    }

    #endregion

}
