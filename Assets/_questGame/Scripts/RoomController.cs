using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] private GameObject _enemiesEmitter;
    [SerializeField] private GameObject _door;

    private EnemiesEmitter _emitterComponent;
    private int _enemiesCount;

    // Start is called before the first frame update
    void Start()
    {
        _emitterComponent = _enemiesEmitter.GetComponent<EnemiesEmitter>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_emitterComponent.GetAliveEnemiesCount() == 0)
        {
            _door.SetActive(false);
        }
    }

}
