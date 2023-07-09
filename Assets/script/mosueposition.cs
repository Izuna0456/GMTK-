using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mosueposition : MonoBehaviour
{
    public GameObject enemyPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 offset = new Vector3(0, 0, 10);

            GameObject enemyObject = Instantiate(enemyPrefab, pos + offset, Quaternion.identity);
            EnemyHealth enemyHealth = enemyObject.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.maxHealth = enemyHealth.maxHealth; // Set the MaxHP value of the enemy prefab
            }
        }
    }
}
