using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject RangeDetect;
    public GameObject Bullet;

    public float AtkTimer;

    private void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(AtkTimer);
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
    }
}