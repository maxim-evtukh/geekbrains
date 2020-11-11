using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesEmitter : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _enemy;
    [SerializeField] private int _enemiesCount;
    [SerializeField] private float _yRotation;
    [SerializeField] private Transform _destinationWaypoint;
    [SerializeField] private ZoneController _zone;

    #endregion


    #region PrivateData

    private List<GameObject> _enemies = new List<GameObject>();

    #endregion


    #region Delegates

    public delegate void EnemiesEmitterDelegate();

    #endregion


    #region Properties

    public EnemiesEmitterDelegate OnAllEnemiesKilled;

    #endregion


    #region UnityMethods

    private void Start()
    {
        float getAxe() => transform.localScale.x > transform.localScale.z
                ? transform.localScale.x
                : transform.localScale.z;

        var middle = getAxe() / 2;

        if (_enemiesCount <= 1)
        {
            InitEnemy(0);
        }
        else
        {
            var offset = getAxe() / (_enemiesCount - 1);
            for (int i = 0; i < _enemiesCount; i++)
            {
                var position = -middle + offset * i;
                InitEnemy(position);
            }
        }
    }

    #endregion


    #region Methods

    private void InitEnemy(float position)
    {
        var enemy = Instantiate(_enemy);

        var vector = new Vector3(transform.localScale.x > transform.localScale.z ? position : transform.position.x,
                                 0,
                                 transform.localScale.x > transform.localScale.z ? transform.position.z : position);

        var navMeshAgent = enemy.GetComponent<NavMeshAgent>();
        navMeshAgent.Warp(vector);
        navMeshAgent.transform.Rotate(0, _yRotation, 0);

        enemy.GetComponent<DeactivationController>().OnDisabled = OnEnemyDisabled;

        if (_destinationWaypoint != null)
        {
            var patrolComponent = enemy.GetComponent<EnemyWaypointPatrol>();

            var destinationVector = new Vector3(transform.localScale.x > transform.localScale.z ? enemy.transform.position.x : _destinationWaypoint.position.x,
                                            0,
                                            transform.localScale.x > transform.localScale.z ? _destinationWaypoint.position.z : enemy.transform.position.z);
            patrolComponent.Waypoints = new Vector3[] { enemy.transform.position, destinationVector };
            patrolComponent.SetZone(_zone);
        }

        _enemies.Add(enemy);
    }

    private void OnEnemyDisabled(int instanceID)
    {
        var enemy = _enemies.FirstOrDefault((obj) => { return obj.GetInstanceID() == instanceID; });
        _enemies.Remove(enemy);
        Destroy(enemy);

        if (_enemies.Count == 0)
        {
            OnAllEnemiesKilled?.Invoke();
        }
    }

    #endregion

}
