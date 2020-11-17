using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields

    [SerializeField] private ShootEmitter _shootEmitter;

    #endregion

    #region Delegates

    public delegate void CaughtDelegate();

    #endregion


    #region Properties

    public CaughtDelegate Caught;

    #endregion


    #region PrivateData

    private bool _canShoot;

    #endregion


    #region UnityMethods

    private void Update()
    {
        if (_canShoot && Input.GetKeyDown(KeyCode.Mouse0))
        {
            _shootEmitter.MakeShotToMouse();
        }
    }

    #endregion


    #region Methods

    public void UnlockGun()
    {
        _canShoot = true;
    }

    public void OnCaught()
    {
        Caught?.Invoke();
    }

    #endregion

}
