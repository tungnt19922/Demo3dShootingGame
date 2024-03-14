using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Debug.Log("bum");
            Destroy(gameObject);
        }

    }

}
