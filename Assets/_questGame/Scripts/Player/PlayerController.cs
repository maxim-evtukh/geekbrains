using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields

    [SerializeField] private ShootEmitter _shootEmitter;
    [SerializeField] private UiController _uiController = null;

    #endregion

    #region Delegates

    public delegate void CaughtDelegate();

    #endregion


    #region Properties

    public CaughtDelegate Caught;

    #endregion


    #region PrivateData

    private bool _canShoot;

    #endregion


    #region UnityMethods

    private void Start()
    {
        if (_uiController != null)
            _uiController.ShowMineHint();
    }

    private void Update()
    {
        if (_canShoot && Input.GetKeyDown(KeyCode.Mouse0))
        {
            var cam = Camera.main;
            var ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                var point = hit.point;
                point.y = _shootEmitter.gameObject.transform.position.y;
                _shootEmitter.MakeShotToTarget(point);
            }
        }
    }

    #endregion


    #region Methods

    public void UnlockGun()
    {
        _canShoot = true;

        if (_uiController != null)
            _uiController.ShowFireHint();
    }

    public void OnCaught()
    {
        Caught?.Invoke();
    }

    #endregion

}
