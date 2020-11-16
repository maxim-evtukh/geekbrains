using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorController : MonoBehaviour
{
    #region Fields

    [SerializeField] private string _openTriggerName;
    [SerializeField] private string _closeTriggerName;

    #endregion


    #region PrivateData

    private Animator _animator;

    #endregion


    #region Properties

    public bool InteractionsEnabled { get; set; }

    #endregion


    #region UnitiMethods

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (InteractionsEnabled && other.CompareTag("Player"))
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (InteractionsEnabled && other.CompareTag("Player"))
        {
            CloseDoor();
        }
    }

    #endregion


    #region Methods

    private void OpenDoor()
    {
        _animator.SetTrigger(_openTriggerName);
    }

    private void CloseDoor()
    {
        _animator.SetTrigger(_closeTriggerName);
    }

    #endregion

}
