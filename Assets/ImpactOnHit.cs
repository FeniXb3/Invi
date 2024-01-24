using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ImpactOnHit : MonoBehaviour
{
    public float radius = 5;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            
            foreach (Collider hitCollider in colliders)
            {
                if (hitCollider.gameObject.CompareTag("Enemy"))
                {
                    Debug.Log(hitCollider.gameObject.name);
                    hitCollider.gameObject.SendMessage("GoTo", transform);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void React()
    {
        Debug.Log("Vase reached");
    }
}
