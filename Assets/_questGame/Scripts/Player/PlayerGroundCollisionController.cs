using UnityEngine;

[RequireComponent(typeof(JumpController))]
public class PlayerGroundCollisionController : MonoBehaviour
{
    #region PrivateData

    private JumpController _jumpController;
    private int _groundID;

    #endregion


    #region UnityMethods

    private void Awake()
    {
        _jumpController = GetComponent<JumpController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _groundID = collision.gameObject.GetInstanceID();
            _jumpController.SetIsGrounded(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && collision.gameObject.GetInstanceID() == _groundID)
        {
            _jumpController.SetIsGrounded(false);
        }
    }

    #endregion

}
