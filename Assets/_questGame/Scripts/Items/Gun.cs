using UnityEngine;

public class Gun : MonoBehaviour
{
    #region UnityMethods

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().UnlockGun();
            Destroy(gameObject);
        }
    }

    #endregion

}
