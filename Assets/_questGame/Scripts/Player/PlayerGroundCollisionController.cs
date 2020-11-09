using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(JumpController))]
public class PlayerGroundCollisionController : MonoBehaviour
{
    private JumpController _jumpController;

    private void Awake()
    {
        _jumpController = GetComponent<JumpController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _jumpController.SetIsGrounded(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _jumpController.SetIsGrounded(false);
        }
    }

}
