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
        InitGun();
    }

    #endregion


    #region Methods

    public void MakeShot()
    {
        InitShot(gameObject.transform);
        DelayLazerShot();
    }

    private void DelayLazerShot()
    {
        _nextShotTime = Time.time + _shotDelay;
    }

    private void InitShot(Transform from)
    {
        var shot = Instantiate(_shoot, from.position, Quaternion.identity);
        var forwardVel = transform.forward * -_shotSpeed;
        shot.GetComponent<Rigidbody>().velocity = new Vector3(forwardVel.x, 0, forwardVel.z);
    }

    private void InitGun()
    {
        if (Time.time > _nextShotTime)
        {
            MakeShot();
        }
    }

    #endregion

}
