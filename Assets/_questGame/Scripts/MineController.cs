using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour
{
    [SerializeField] private GameObject _mine;

    private GameObject _instantiatedMine;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _instantiatedMine == null)
        {
            _instantiatedMine = Instantiate(_mine, new Vector3(gameObject.transform.position.x, _mine.transform.localScale.y / 2, gameObject.transform.position.z), Quaternion.identity);
        }
    }
}
