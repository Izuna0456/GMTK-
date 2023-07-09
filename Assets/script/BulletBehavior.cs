using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 10f;
    public int Dmg = 5;

    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = -transform.right * speed; // move the bullet object to the left
    }
    
    void OnBecameInvisible() // destroy when out of screen
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(Dmg);
            }

            Destroy(gameObject);
        }
    }
}
