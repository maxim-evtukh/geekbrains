using UnityEngine;

public class GargoyleController : MonoBehaviour
{
    #region Fields

    [SerializeField] private GargoylePointOfViewController _pointOfViewController;
    [SerializeField] private ShootEmitter _shootEmitter;

    #endregion


    #region UnityMethods

    private void OnEnable()
    {
        _pointOfViewController.OnPlayerFound += OnPlayerFound;
        _pointOfViewController.OnPlayerLost += OnPlayerLost;
    }

    private void OnDisable()
    {
        _pointOfViewController.OnPlayerFound -= OnPlayerFound;
        _pointOfViewController.OnPlayerLost -= OnPlayerLost;
    }

    #endregion


    #region Methods

    private void OnPlayerFound()
    {
        _shootEmitter.enabled = true;
    }

    private void OnPlayerLost()
    {
        _shootEmitter.enabled = false;
    }

    #endregion

}
