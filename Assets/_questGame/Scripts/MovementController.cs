using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;

    private Vector3 _direction;

    // Start is called before the first frame update
    void Start()
    {
        _direction = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        transform.position += _direction * (_speed * Time.deltaTime);
    }
}
