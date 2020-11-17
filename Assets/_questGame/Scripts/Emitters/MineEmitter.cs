using UnityEngine;

public class MineEmitter : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _mine;

    #endregion


    #region PrivateData

    private GameObject _instantiatedMine;

    #endregion


    #region UnityMethods

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _instantiatedMine == null)
        {
            _instantiatedMine = Instantiate(_mine, new Vector3(gameObject.transform.position.x, _mine.transform.localScale.y / 2, gameObject.transform.position.z), Quaternion.identity);
            _instantiatedMine.GetComponent<DeactivationController>().OnDisabled = OnMineDisabled;
        }
    }

    #endregion


    #region Methods

    private void OnMineDisabled(int instanceID)
    {
        Destroy(_instantiatedMine);
        _instantiatedMine = null;
    }

    #endregion

}
