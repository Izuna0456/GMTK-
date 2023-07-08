using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public Collider Detectcollider;
    public Transform FirePoint;
    public GameObject Bullet;
    public string enemyTag = "Enemy"; // Tag to identify enemy objects
    public float shootTime = 1.5f; // Attack every 1.5 sec
    public float attackRange; // The range that tower will start shooting

    private float resetTime = 0f; // Reset the time count
    private bool isAttacking = false; // Flag to track if the tower is attacking

    private void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); // Find all objects with the specified tag

        foreach (GameObject enemy in enemies)
        {
            float distanceToTower = Vector3.Distance(transform.position, enemy.transform.position);
            float distanceAbs = Math.Abs(distanceToTower);

            if (distanceAbs <= attackRange) // Tower is within range to attack the enemy
            {
                isAttacking = true;
                break;
            }
            else
            {
               isAttacking = false;
            }
        }

        if (isAttacking)
        {
            if (shootTime >= 2f)
            {
                Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
                shootTime = resetTime;
            }

            shootTime += Time.deltaTime;
        }
    }
}
