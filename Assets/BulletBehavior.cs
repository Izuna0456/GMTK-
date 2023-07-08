using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = -transform.right * speed;
    }
    
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void TriggerHit()
    {
        Destroy(gameObject);
    }
}
