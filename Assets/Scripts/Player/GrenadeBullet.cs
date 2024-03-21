using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float explosionRadius;
    public float explosionForce;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        BlowObjects();
    }

    private void BlowObjects()
    {
        Collider[] affectedObject = Physics.OverlapSphere(transform.position, explosionRadius);
        for (int i = 0; i< affectedObject.Length; i++)
        {
            Rigidbody rigidbody = affectedObject[i].attachedRigidbody;
            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(explosionForce,transform.position, explosionRadius, 1, ForceMode.Impulse);
            }
        }
    }
}
