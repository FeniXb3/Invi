using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactOnHit : MonoBehaviour
{
    public float radius = 5;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            Debug.Log(colliders.Length);
            foreach (Collider hitCollider in colliders)
            {
                if (hitCollider.gameObject.CompareTag("Enemy"))
                {
                    Debug.Log(hitCollider.gameObject.name);
                }
            }
        }
    }
}
