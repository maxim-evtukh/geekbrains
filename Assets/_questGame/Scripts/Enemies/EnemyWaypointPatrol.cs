using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWaypointPatrol : MonoBehaviour
{
    #region Fields

    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private float _waitTime = 2.0f;

    #endregion


    #region Properties

    public Vector3[] Waypoints;

    #endregion


    #region PrivateData

    private ZoneController _zone;
    private GameObject _invader;
    private Coroutine _coroutine;

    #endregion


    #region PrivateData

    private int _currentWaypointIndex;

    #endregion


    #region UnityMethods

    private void OnDisable()
    {
        if (_zone != null)
        {
            _zone.Invaded -= OnPlayerInvaded;
        }
    }

    private void Start()
    {
        navMeshAgent.SetDestination(Waypoints[0]);
    }

    private void Update()
    {
        if (_invader != null)
        {
            navMeshAgent.SetDestination(_invader.transform.position);
        }
        else if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % Waypoints.Length;
            navMeshAgent.SetDestination(Waypoints[_currentWaypointIndex]);
        }
    }

    #endregion


    #region Methods

    public void SetZone(ZoneController zone)
    {
        if (_zone != null)
        {
            _zone.Invaded -= OnPlayerInvaded;
        }

        _zone = zone;

        if (_zone != null)
        {
            _zone.Invaded += OnPlayerInvaded;
        }
    }

    private void OnPlayerInvaded(object sender, GameObject e)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _invader = e;

        if (_invader == null)
        {
            _coroutine = StartCoroutine(WaitBeforeReturnToPatrol());
        }
    }

    #endregion


    #region Methods

    private IEnumerator WaitBeforeReturnToPatrol()
    {
        yield return new WaitForSeconds(_waitTime);
        _currentWaypointIndex = 0;
        navMeshAgent.SetDestination(Waypoints[0]);
    }

    #endregion

}
