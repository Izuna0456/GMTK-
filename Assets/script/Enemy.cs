using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float attackDamage;
    public float attackSpeed;
    
    private float canAttack;
    private bool stopMove = false;

    public Rigidbody2D rb;

    void Update()
    {
        if (!stopMove)
        {
            rb.velocity = transform.right * speed; // Move the enemy object to the right
        }
        else
        {
            Tower_HP tower_HP = FindObjectOfType<Tower_HP>();

            if (tower_HP != null)
            {
                if (attackSpeed <= canAttack)
                {
                    tower_HP.TakeDamage(attackDamage);
                    canAttack = 0f;
                }

                canAttack += Time.deltaTime;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            stopMove = true; // Stop the enemy from moving
            rb.velocity = Vector2.zero; // Set the enemy's velocity to zero

        }
    }
}
