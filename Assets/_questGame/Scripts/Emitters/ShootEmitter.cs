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
            InitShot();
            DelayLazerShot();
        }
    }

    public void MakeShotToMouse()
    {
        if (Time.time > _nextShotTime)
        {
            InitShot(true);
            DelayLazerShot();
        }
    }

    private void DelayLazerShot()
    {
        _nextShotTime = Time.time + _shotDelay;
    }

    private void InitShot(bool isShootingToMouse = false)
    {
        var from = gameObject.transform;

        if (isShootingToMouse)
        {
            //    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //    var rotation = Quaternion.LookRotation(ray.direction);
            //    rotation.x = 0;
            //    rotation.z = 0;

            //    transform.rotation = rotation;
        }

        var shot = Instantiate(_shoot, from.position, from.rotation);
        var rigidbody = shot.GetComponent<Rigidbody>();

        var impulse = transform.forward * rigidbody.mass * _shotSpeed;

        rigidbody.AddForce(impulse);

        Destroy(shot, _shotLifeTime);
    }

    #endregion

}
