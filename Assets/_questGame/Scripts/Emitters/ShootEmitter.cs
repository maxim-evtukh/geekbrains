using UnityEngine;

public class ShootEmitter : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _shoot;
    [SerializeField] private float _firstShotDelay;
    [SerializeField] private float _shotDelay;
    [SerializeField] private float _shotSpeed;
    [SerializeField] private float _shotLifeTime = 3.0f;

    #endregion


    #region PrivateData

    private float _nextShotTime;

    #endregion


    #region UnityMethods

    private void OnEnable()
    {
        _nextShotTime = Time.time + _firstShotDelay;
    }

    private void Update()
    {
        MakeShot();
    }

    #endregion


    #region Methods

    public void MakeShot()
    {
        if (Time.time > _nextShotTime)
        {
            InitShot(Vector3.zero);
            DelayLazerShot();
        }
    }

    public void MakeShotToTarget(Vector3 targetPosition)
    {
        if (Time.time > _nextShotTime)
        {
            InitShot(targetPosition);
            DelayLazerShot();
        }
    }

    private void DelayLazerShot()
    {
        _nextShotTime = Time.time + _shotDelay;
    }

    private void InitShot(Vector3 targetPosition)
    {
        var from = gameObject.transform;
        var shot = Instantiate(_shoot, from.position, from.rotation);
        var rigidbody = shot.GetComponent<Rigidbody>();

        Vector3 impulse;

        if (targetPosition != Vector3.zero)
        {
            var dir = (targetPosition - transform.position).normalized;
            impulse = dir.normalized * rigidbody.mass * _shotSpeed;

            shot.transform.LookAt(impulse);
        }
        else
        {
            impulse = transform.forward * rigidbody.mass * _shotSpeed;
        }

        rigidbody.AddForce(impulse);

        Destroy(shot, _shotLifeTime);
    }

    #endregion

}
