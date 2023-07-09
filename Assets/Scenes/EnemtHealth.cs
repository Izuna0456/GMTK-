using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemtHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateHealth(float mod)
    {
        health += mod;
        if (health > maxHealth)
        {
            maxHealth = health;
        }
        else if (health <= 0f) 
        { 
            health = 0f;
            
        }
    }
}
