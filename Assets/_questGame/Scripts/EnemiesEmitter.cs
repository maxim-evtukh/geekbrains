using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesEmitter : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private int _enemiesCount;

    [SerializeField] private float _yRotation;

    [SerializeField] private Transform _destinationWaypoint;

    private List<GameObject> _enemies = new List<GameObject>();

    // Start is called before the first frame update
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

    private void InitEnemy(float position)
    {
        var enemy = Instantiate(_enemy);

        var vector = new Vector3(transform.localScale.x > transform.localScale.z ? position : transform.position.x,
                                 0,
                                 transform.localScale.x > transform.localScale.z ? transform.position.z : position);

        var navMeshAgent = enemy.GetComponent<NavMeshAgent>();
        navMeshAgent.Warp(vector);
        navMeshAgent.transform.Rotate(0, _yRotation, 0);

        var destinationVector = new Vector3(transform.localScale.x > transform.localScale.z ? enemy.transform.position.x : _destinationWaypoint.position.x,
                                            0,
                                            transform.localScale.x > transform.localScale.z ? _destinationWaypoint.position.z : enemy.transform.position.z);

        enemy.GetComponent<DeactivationController>().onDisable = OnEnemyDisabled;
        enemy.GetComponent<EnemyWaypointPatrol>().waypoints = new Vector3[] { enemy.transform.position, destinationVector };

        _enemies.Add(enemy);
    }

    private void OnEnemyDisabled(int instanceID)
    {
        var enemy = _enemies.FirstOrDefault((obj) => { return obj.GetInstanceID() == instanceID; });
        _enemies.Remove(enemy);
        Destroy(enemy);
    }

    public int GetEnemiesCount()
    {
        return _enemiesCount;
    }

    public int GetAliveEnemiesCount()
    {
        return _enemies.Count;
    }

}
