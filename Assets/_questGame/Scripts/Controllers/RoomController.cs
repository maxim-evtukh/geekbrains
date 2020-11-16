using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    #region Fields

    [SerializeField] private EnemiesEmitter _enemiesEmitter;
    [SerializeField] private DoorController _door;

    #endregion


    #region UnityMethods

    private void OnEnable()
    {
        _enemiesEmitter.OnAllEnemiesKilled += OpenDoor;

    }

    private void OnDisable()
    {
        _enemiesEmitter.OnAllEnemiesKilled -= OpenDoor;
    }

    #endregion


    #region Methods

    private void OpenDoor()
    {
        _enemiesEmitter.OnAllEnemiesKilled -= OpenDoor;

        if (_door != null)
        {
            _door.InteractionsEnabled = true;
        }
    }

    #endregion

}
