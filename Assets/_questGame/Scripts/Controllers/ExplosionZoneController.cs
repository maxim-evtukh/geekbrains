using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ExplosionZoneController : MonoBehaviour
{
    #region Fields
    [SerializeField] private float _explosionForce = 30.0f;
    #endregion


    #region UnityMethods

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.gameObject;
        if (obj.CompareTag("Enemy"))
        {
            var startPos = gameObject.transform.position;
            startPos.y += 0.5f;

            var endPos = obj.transform.position;
            endPos.y += 0.5f;

            var dir = endPos - startPos;
            var hasHit = Physics.Raycast(startPos, dir, out var hit, dir.magnitude);

            if (hasHit && hit.collider.gameObject.CompareTag("Enemy"))
            {
                var agent = obj.gameObject.GetComponent<NavMeshAgent>();
                agent.enabled = false;

                var rigidbody = obj.gameObject.GetComponent<Rigidbody>();
                rigidbody.isKinematic = false;

                var force = dir.normalized * _explosionForce;
                rigidbody.AddForce(force, ForceMode.Impulse);

                Destroy(obj, 5.0f);
            }
        }
    }

    #endregion

}
