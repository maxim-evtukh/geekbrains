using System;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    #region Events

    public EventHandler<GameObject> Invaded;

    #endregion


    #region UnityMethods

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnInvaded(collision.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnInvaded(null);
        }
    }

    #endregion


    #region Methods

    private void OnInvaded(GameObject gameObject)
    {
        Invaded?.Invoke(this, gameObject);
    }

    #endregion


}
