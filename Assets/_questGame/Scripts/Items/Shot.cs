using UnityEngine;

public class Shot : MonoBehaviour
{

    #region UnityMethods

    private void OnTriggerEnter(Collider other)
    {
        if (IsPlayerHit(other) || IsEnemyHit(other))
        {
            if (IsEnemyHit(other))
                other.gameObject.GetComponent<PlayerController>().OnCaught();
            else
                other.gameObject.SetActive(false);

            Destroy(gameObject);
        }
        else if (!IsFriendlyFire(other) && !IsInvisibleObject(other))
        {
            Destroy(gameObject);
        }
    }

    #endregion


    #region Methods

    private bool IsEnemyHit(Collider other)
    {
        return other.CompareTag("Player") && CompareTag("EnemyShot");
    }

    private bool IsPlayerHit(Collider other)
    {
        return other.CompareTag("Enemy") && CompareTag("PlayerShot");
    }

    private bool IsFriendlyFire(Collider other)
    {
        return (other.CompareTag("Enemy") && CompareTag("EnemyShot")) || (other.CompareTag("Player") && CompareTag("PlayerShot"));
    }

    private bool IsInvisibleObject(Collider other)
    {
        return other.CompareTag("Invisible");
    }

    #endregion

}
