using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields

    [SerializeField] private ShootEmitter _shootEmitter;

    #endregion


    #region PrivateData

    private bool _canShoot;

    #endregion


    #region UnityMethods

    private void Update()
    {
        if (_canShoot && Input.GetKeyDown(KeyCode.Space))
        {
            _shootEmitter.MakeShot();
        }
    }

    #endregion


    #region Methods

    public void UnlockGun()
    {
        _canShoot = true;
    }

    #endregion

}
