using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;

public class TowerAttack : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject Bullet;
    public AudioSource shootsfx;
    public string enemyTag = "Enemy"; // Tag to identify enemy objects
    public float atkTime = 1.5f; // Shot every 1.5 sec
    public float attackRange; // The range at which the tower will start shooting
    public float upgradeTime = 30f;

    private float shootTime;
    private int upState = 0;
    private bool isAttacking = false; // Flag to track if the tower is attacking

    private void Start()
    {
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
    GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

    bool foundEnemyInRange = false; // Flag to track if an enemy is within range

    foreach (GameObject enemy in enemies)
    {
        float distanceToTower = Vector3.Distance(transform.position, enemy.transform.position);
        float distanceAbs = Mathf.Abs(distanceToTower);

        if (distanceAbs <= attackRange)
        {
            foundEnemyInRange = true;
            break;
        }
    }

    isAttacking = foundEnemyInRange; // Update the isAttacking flag based on whether an enemy is within range or not

    if (isAttacking)
    {
        if (shootTime >= atkTime)
        {
            shootsfx.Play();
            Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
            shootTime = 0f;
        }

        shootTime += Time.deltaTime;
    }
}

    public void upgrade()
    {
        BulletBehavior bh = FindObjectOfType<BulletBehavior>();

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
                if (bh != null)
                {
                    bh.Dmg += 3;
                }
            }

            upState++;
        }
    }
}
