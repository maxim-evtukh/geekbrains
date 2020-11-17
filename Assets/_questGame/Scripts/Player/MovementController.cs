using UnityEngine;

public class MovementController : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _turnSpeed = 20f;

    #endregion


    #region PrivateData

    private Animator _animator;
    private Vector3 _movement;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _movement.Set(horizontal, 0f, vertical);

        _animator.SetBool("IsWalking", horizontal != 0 || vertical != 0);

        transform.position += _movement * (_speed * Time.deltaTime);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _movement, _turnSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(desiredForward);
    }

    #endregion

}
