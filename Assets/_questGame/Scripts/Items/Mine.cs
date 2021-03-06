﻿using UnityEngine;

public class Mine : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _destroyDelay;
    [SerializeField] private GameObject _explosionPrefab;

    #endregion


    #region PrivateData

    private ParticleSystem _particleSystem;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _particleSystem = _explosionPrefab.GetComponentInChildren<ParticleSystem>();

        var selfDestroyTime = Time.time + _destroyDelay;
        Invoke(nameof(Explode), selfDestroyTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Explode();
        }
    }

    #endregion


    #region Methods

    private void Explode()
    {
        gameObject.SetActive(false);

        var explosion = Instantiate(_explosionPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(explosion, _particleSystem.main.duration);
    }

    #endregion

}
