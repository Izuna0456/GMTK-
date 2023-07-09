using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;

    void Start()
    {
        rb.velocity = -transform.right * speed; // move the bullet object to left
    }
    
    void OnBecameInvisible() // destroy when out of screen
    {
        Destroy(gameObject);
    }

    void TriggerHit() // destroy when hit on enemy
    {
        Destroy(gameObject);
    }
}
