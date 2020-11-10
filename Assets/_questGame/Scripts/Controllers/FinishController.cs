using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    #region Fields

    [SerializeField] private Canvas _imageCanvas;

    #endregion


    #region UnityMethods

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _imageCanvas.gameObject.SetActive(true);
        }
    }

    #endregion

}
