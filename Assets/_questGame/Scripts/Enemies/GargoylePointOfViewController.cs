﻿using UnityEngine;
using UnityEngine.AI;

public class GargoylePointOfViewController : MonoBehaviour
{
    #region Fields

    [SerializeField] private NavMeshAgent _navMeshAgent;

    #endregion


    #region PrivateData

    private GameObject _player;
    private Quaternion _startRotation;

    #endregion


    #region Delegates

    public delegate void PlayerObserver();

    #endregion


    #region Properties

    public PlayerObserver OnPlayerFound;
    public PlayerObserver OnPlayerLost;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _startRotation = _navMeshAgent.transform.rotation;
    }

    private void Update()
    {
        if (_player != null)
        {
            var pos = _player.transform.position - _navMeshAgent.transform.position;
            var rotation = Quaternion.LookRotation(pos);
            rotation.x = 0;
            rotation.z = 0;

            _navMeshAgent.transform.rotation = rotation;
        }
        else
        {
            _navMeshAgent.transform.rotation = _startRotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player = other.gameObject;
            OnPlayerFound?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player = null;
            OnPlayerLost?.Invoke();
        }
    }

    #endregion

}
