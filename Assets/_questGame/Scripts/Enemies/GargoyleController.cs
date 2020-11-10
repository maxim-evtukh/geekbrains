using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargoyleController : MonoBehaviour
{
    #region Fields

    [SerializeField] private GargoyleViewController _viewController;
    [SerializeField] private ShootEmitter _shootEmitter;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _viewController.OnPlayerFound = OnPlayerFound;
        _viewController.OnPlayerLost = OnPlayerLost;
    }

    #endregion


    #region Methods

    private void OnPlayerFound()
    {
        _shootEmitter.enabled = true;
    }

    private void OnPlayerLost()
    {
        _shootEmitter.enabled = false;
    }

    #endregion

}
