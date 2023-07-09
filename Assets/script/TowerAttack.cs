using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject Bullet;
    public string enemyTag = "Enemy"; // Tag to identify enemy objects
    public float atkTime = 1.5f; // Shot every 1.5 sec
    public float attackRange; // The range at which the tower will start shooting
    public float upgradeTime = 30f;

    private int bulletDmg = 0; // Declare bulletDmg as a class-level field and assign an initial value

    private float shootTime;
    private int upState = 0;
    private bool isAttacking = false; // Flag to track if the tower is attacking

    private void Start()
    {
        BulletBehavior bh = FindObjectOfType<BulletBehavior>();
        if (bh != null)
        {
            bulletDmg = bh.Dmg;
        }

        StartCoroutine(UpgradeCoroutine());
    }

    private IEnumerator UpgradeCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(upgradeTime); // Wait for 30 seconds
            upgrade(); // Call the upgrade function
        }
    }

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
            if (shootTime >= atkTime)
            {
                Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
                shootTime = 0f;
            }

            shootTime += Time.deltaTime;
        }
    }

    public void upgrade()
    {
        if (upState != 5)
        {
            if (upState == 0 || upState == 3)
            {
                atkTime -= 0.2f;
            }
            if (upState == 1 || upState == 4)
            {
                attackRange += 5;
            }
            if (upState == 2 || upState == 5)
            {
                bulletDmg += 3;
            }

            upState++;
        }
    }
}
