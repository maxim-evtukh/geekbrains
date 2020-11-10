using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEmitter : MonoBehaviour
{
    #region Fields

    [SerializeField] private EnemiesEmitter _enemiesEmitter;
    [SerializeField] private GameObject _gun;

    #endregion


    #region UnitMethods

    private void OnEnable()
    {
        _enemiesEmitter.OnAllEnemiesKilled += InitGun;
    }

    private void OnDisable()
    {
        _enemiesEmitter.OnAllEnemiesKilled -= InitGun;
    }

    #endregion


    #region Methods

    private void InitGun()
    {
        _enemiesEmitter.OnAllEnemiesKilled -= InitGun;
        Instantiate(_gun, transform);
    }

    #endregion

}
