using UnityEngine;

public class GunEmitter : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _gun;
    [SerializeField] private EnemiesEmitter _enemiesEmitter;

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
