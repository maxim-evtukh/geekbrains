using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _mineHint;
    [SerializeField] private GameObject _fireHint;
    [SerializeField] private float _hintDelay;

    #endregion


    #region Methods

    public void ShowMineHint()
    {
        _mineHint.SetActive(true);
        StartCoroutine(HideHintRoutine(_mineHint));
    }

    public void ShowFireHint()
    {
        _fireHint.SetActive(true);
        StartCoroutine(HideHintRoutine(_fireHint));
    }

    private IEnumerator HideHintRoutine(GameObject hint)
    {
        yield return new WaitForSeconds(_hintDelay);

        hint.SetActive(false);
    }

    #endregion

}
