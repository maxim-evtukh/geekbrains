using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    [SerializeField] private Canvas _imageCanvas;
    //[SerializeField] private GameObject _scene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //_scene.SetActive(false);
            _imageCanvas.gameObject.SetActive(true);
        }
    }

}
