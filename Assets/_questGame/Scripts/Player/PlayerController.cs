using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _gun;

    private ShootEmitter _shootEmitter;
    private bool _canShoot;

    private void Start()
    {
        _shootEmitter = _gun.GetComponent<ShootEmitter>();
    }

    private void Update()
    {
        if (_canShoot && Input.GetKeyDown(KeyCode.Space))
        {
            _shootEmitter.MakeShot();
        }
    }

    public void UnlockGun()
    {
        _canShoot = true;
    }
}
