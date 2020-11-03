using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargoyleController : MonoBehaviour
{
    [SerializeField] private GameObject _view;
    [SerializeField] private GameObject _gun;

    private GargoyleViewController _viewController;
    private ShootEmitter _shootEmitter;

    private void Start()
    {
        _viewController = _view.GetComponent<GargoyleViewController>();
        _viewController.OnPlayerFound = OnPlayerFound;
        _viewController.OnPlayerLost = OnPlayerLost;

        _shootEmitter = _gun.GetComponent<ShootEmitter>();
    }

    private void OnPlayerFound()
    {
        _shootEmitter.Enabled = true;
    }

    private void OnPlayerLost()
    {
        _shootEmitter.Enabled = false;
    }
}
