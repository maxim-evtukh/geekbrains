using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GargoyleViewController : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    private void Update()
    {
        if (_player != null)
        {
            var pos = _player.transform.position - _navMeshAgent.transform.position;
            _navMeshAgent.transform.rotation = Quaternion.LookRotation(pos);
        }
        else
        {
            _navMeshAgent.transform.rotation = Quaternion.identity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player = null;
        }
    }


}
