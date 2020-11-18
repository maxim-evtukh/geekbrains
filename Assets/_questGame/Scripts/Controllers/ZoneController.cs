using System;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    #region Events

    public EventHandler<GameObject> Invaded;

    #endregion


    #region Properties

    public GameObject Invader { get; private set; }

    #endregion


    #region UnityMethods

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invader = collision.gameObject;
            OnInvaded();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invader = null;
            OnInvaded();
        }
    }

    #endregion


    #region Methods

    private void OnInvaded()
    {
        Invaded?.Invoke(this, Invader);
    }

    #endregion


}
