using UnityEngine;
using System.Collections;

public class SwampController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var jumpController = other.GetComponent<JumpController>();
        if (jumpController != null)
        {
            jumpController.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var jumpController = other.GetComponent<JumpController>();
        if (jumpController != null)
        {
            jumpController.enabled = true;
        }
    }
}
