using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] private EnemiesEmitter _emitterComponent;
    [SerializeField] private GameObject _door;

    private void Start()
    {
        _emitterComponent.OnAllEnemiesKilled = OpenDoor;
    }

    private void OpenDoor()
    {
        _door.SetActive(false);
    }

}
