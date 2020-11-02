using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] private GameObject _enemiesEmitter;

    private EnemiesEmitter _emitterComponent;
    private int _enemiesCount;

    // Start is called before the first frame update
    void Start()
    {
        _emitterComponent = _enemiesEmitter.GetComponent<EnemiesEmitter>();
        _enemiesCount = _emitterComponent.GetEnemiesCount();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
