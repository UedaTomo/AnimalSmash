using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            WallReflect(other.gameObject, transform.forward);
        }
    }

    void WallReflect(GameObject obj, Vector3 wallNormal)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 incomingVelocity = rb.velocity;
            Vector3 reflectedVelocity = Vector3.Reflect(incomingVelocity, wallNormal);
            rb.velocity = reflectedVelocity;
        }
    }
}