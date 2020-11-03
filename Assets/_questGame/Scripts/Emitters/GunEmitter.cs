using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEmitter : MonoBehaviour
{
    [SerializeField] private GameObject _enemiesEmitter;
    [SerializeField] private GameObject _gun;

    private EnemiesEmitter _emitterComponent;
    private bool _instantiated;

    // Start is called before the first frame update
    void Start()
    {
        _emitterComponent = _enemiesEmitter.GetComponent<EnemiesEmitter>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_emitterComponent.GetAliveEnemiesCount() == 0 && !_instantiated)
        {
            _instantiated = true;
            Instantiate(_gun, transform);
        }
    }

}
