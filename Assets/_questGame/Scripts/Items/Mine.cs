using UnityEngine;

public class Mine : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _destroyDelay;
    [SerializeField] private GameObject _explosionPrefab;

    #endregion


    #region PrivateData

    private float _selfDestroyTime;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _selfDestroyTime = Time.time + _destroyDelay;
    }

    private void Update()
    {
        if (Time.time > _selfDestroyTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);

            var explosion = Instantiate(_explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(explosion, 4.0f);
        }
    }

    #endregion

}
