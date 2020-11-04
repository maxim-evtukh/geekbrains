using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
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

    private void OnTriggerEnter(Collider other)
    {
        if (IsPlayerHit(other) || IsEnemyHit(other))
        {
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if (!IsFriendlyFire(other) && !IsInvisibleObject(other))
        {
            Destroy(gameObject);
        }
    }
}
