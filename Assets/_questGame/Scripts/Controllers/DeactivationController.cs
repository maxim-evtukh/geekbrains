using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivationController : MonoBehaviour
{
    #region Delegates

    public delegate void DisableDelegate(int instanceID);

    #endregion


    #region Properties

    public DisableDelegate OnDisabled;

    #endregion


    #region UnityMethods

    private void OnDisable()
    {
        OnDisabled?.Invoke(gameObject.GetInstanceID());
    }

    #endregion

}
