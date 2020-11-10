using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEmitter : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _shoot;
    [SerializeField] private float _firstShotDelay;
    [SerializeField] private float _shotDelay;
    [SerializeField] private float _shotSpeed;
    [SerializeField] private float _shotLifeTime = 3.0f;

    #endregion


    #region PrivateData

    private float _nextShotTime;

    #endregion


    #region UnityMethods

    private void OnEnable()
    {
        _nextShotTime = Time.time + _firstShotDelay;
    }

    private void Update()
    {
        MakeShot();
    }

    #endregion


    #region Methods

    public void MakeShot()
    {
        if (Time.time > _nextShotTime)
        {
            InitShot(gameObject.transform);
            DelayLazerShot();
        }
    }

    private void DelayLazerShot()
    {
        _nextShotTime = Time.time + _shotDelay;
    }

    private void InitShot(Transform from)
    {
        var shot = Instantiate(_shoot, from.position, from.rotation);
        var rigidbody = shot.GetComponent<Rigidbody>();

        var impulse = from.forward * rigidbody.mass * _shotSpeed;
        rigidbody.AddForce(impulse);

        Destroy(shot, _shotLifeTime);
    }

    #endregion

}
