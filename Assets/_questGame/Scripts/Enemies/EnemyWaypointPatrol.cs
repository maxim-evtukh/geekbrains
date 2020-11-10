using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWaypointPatrol : MonoBehaviour
{
    #region Fields

    [SerializeField] private NavMeshAgent navMeshAgent;

    #endregion


    #region Properties

    public Vector3[] Waypoints;

    #endregion


    #region PrivateData

    private int _currentWaypointIndex;

    #endregion


    #region UnityMethods

    private void Start()
    {
        navMeshAgent.SetDestination(Waypoints[0]);
    }

    private void Update()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % Waypoints.Length;
            navMeshAgent.SetDestination(Waypoints[_currentWaypointIndex]);
        }
    }

    #endregion

}
