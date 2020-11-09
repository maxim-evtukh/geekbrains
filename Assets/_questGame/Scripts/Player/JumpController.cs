using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10;

    private Rigidbody _rigidbody;
    private bool _isGrounded = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(new Vector3(0, _jumpForce, 0));
        }
    }

    public void SetIsGrounded(bool isGrounded)
    {
        _isGrounded = isGrounded;
    }
}
