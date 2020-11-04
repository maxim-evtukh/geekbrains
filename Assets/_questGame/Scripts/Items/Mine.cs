using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _destroyDelay;

    private float _selfDestroyTime;

    private void Start()
    {
        _selfDestroyTime = Time.time + _destroyDelay;
    }

    private void Update()
    {
        if (Time.time > _selfDestroyTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

}
