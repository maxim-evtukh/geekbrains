using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivationController : MonoBehaviour
{
    public delegate void DisableDelegate(int instanceID);

    public DisableDelegate onDisable;

    private void OnDisable()
    {
        onDisable?.Invoke(gameObject.GetInstanceID());
    }

}
