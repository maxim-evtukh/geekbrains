using System.Collections;
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
    [SerializeField] private int _wavesCount = 1;
    [SerializeField] private float _wavesDelay = 5.0f;

    #endregion


    #region PrivateData

    private List<GameObject> _enemies = new List<GameObject>();
    private Coroutine _wavesCoroutine;
    private int _emittedWavesCount = 0;

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
        InitWave();

        if (_wavesCount > 1)
        {
            _wavesCoroutine = StartCoroutine(nameof(StartWavesRoutine));
        }
    }

    #endregion


    #region Methods

    private IEnumerator StartWavesRoutine()
    {
        while (_emittedWavesCount < _wavesCount)
        {
            yield return new WaitForSeconds(_wavesDelay);

            InitWave();
        }
    }

    private void InitWave()
    {
        _emittedWavesCount += 1;

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

        if (_enemies.Count == 0 && _emittedWavesCount == _wavesCount)
        {
            OnAllEnemiesKilled?.Invoke();
        }
    }

    #endregion

}
