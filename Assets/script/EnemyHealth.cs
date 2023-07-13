using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        Debug.Log("Enemy health: " + health);

        if (health <= 0f) 
        { 
            health = 0f;
            Destroy(gameObject);
        }

    }
}