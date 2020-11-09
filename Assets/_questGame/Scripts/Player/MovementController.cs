using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _turnSpeed = 20f;

    private Vector3 _movement;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _movement.Set(horizontal, 0f, vertical);

        transform.position += _movement * (_speed * Time.deltaTime);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _movement, _turnSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(desiredForward);
    }

}
