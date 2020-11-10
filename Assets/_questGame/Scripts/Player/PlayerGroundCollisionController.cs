using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(JumpController))]
public class PlayerGroundCollisionController : MonoBehaviour
{
    #region PrivateData

    private JumpController _jumpController;

    #endregion


    #region UnityMethods

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

    #endregion

}
