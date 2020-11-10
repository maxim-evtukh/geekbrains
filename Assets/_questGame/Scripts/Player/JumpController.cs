using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JumpController : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _jumpForce = 10;

    #endregion


    #region PrivateData

    private Rigidbody _rigidbody;
    private bool _isGrounded = true;

    #endregion


    #region UnityMethods

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

    #endregion


    #region Methods

    public void SetIsGrounded(bool isGrounded)
    {
        _isGrounded = isGrounded;
    }

    #endregion
}
