using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEmitter : MonoBehaviour
{
    [SerializeField] private GameObject _shoot;
    [SerializeField] private float _firstShotDelay, _shotDelay;
    [SerializeField] private float _shotSpeed;

    private float _nextShotTime;

    private bool _enabled;
    public bool Enabled
    {
        get => _enabled;
        set
        {
            _enabled = value;
            if (_enabled)
            {
                OnEnabled();
            }
        }
    }

    private void OnEnabled()
    {
        _nextShotTime = Time.time + _firstShotDelay;
    }


    private void Update()
    {
        InitGun();
    }

    private void DelayLazerShot()
    {
        _nextShotTime = Time.time + _shotDelay;
    }

    private void MakeShot()
    {
        InitShot(gameObject.transform);
    }

    private void InitShot(Transform from)
    {
        var shot = Instantiate(_shoot, from.parent);
        var forwardVel = transform.forward * -_shotSpeed;
        shot.GetComponent<Rigidbody>().velocity = new Vector3(forwardVel.x, 0, forwardVel.z);
    }

    public void InitGun()
    {
        if (_enabled && Time.time > _nextShotTime)
        {
            MakeShot();
            DelayLazerShot();
        }
    }
}
