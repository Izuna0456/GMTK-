using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject enemyPrefab4;
    public GameObject enemyPrefab5;

    public GameObject objectPrefab; // Reference to the object prefab
    public GameObject objectPrefab2;
    public GameObject objectPrefab3;
    public GameObject objectPrefab4;
    public GameObject objectPrefab5;

    public Transform spawnPoint;

    private EnergyBar energyBar;

    private void Start()
    {
        energyBar = FindObjectOfType<EnergyBar>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null)
            {
                if (energyBar.CurrentEnergy > GetEnemyCost(hit.collider.gameObject))
                {
                    if (hit.collider.gameObject == objectPrefab)
                    {
                        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                    }
                    else if (hit.collider.gameObject == objectPrefab2)
                    {
                        Instantiate(enemyPrefab2, spawnPoint.position, spawnPoint.rotation);
                    }
                    else if (hit.collider.gameObject == objectPrefab3)
                    {
                        Instantiate(enemyPrefab3, spawnPoint.position, spawnPoint.rotation);
                    }
                    else if (hit.collider.gameObject == objectPrefab4)
                    {
                        Instantiate(enemyPrefab4, spawnPoint.position, spawnPoint.rotation);
                    }
                    else if (hit.collider.gameObject == objectPrefab5)
                    {
                        Instantiate(enemyPrefab5, spawnPoint.position, spawnPoint.rotation);
                    }

                    energyBar.CurrentEnergy -= GetEnemyCost(hit.collider.gameObject);
                }
            }
        }
    }

    private int GetEnemyCost(GameObject ObjectPrefab)
    {

        if (ObjectPrefab == objectPrefab)
        {
            return 1;
        }
        else if (ObjectPrefab == objectPrefab2)
        {
            return 2;
        }
        else if (ObjectPrefab == objectPrefab3)
        {
            return 3;
        }
        else if (ObjectPrefab == objectPrefab4)
        {
            return 3;
        }
        else if (ObjectPrefab == objectPrefab5)
        {
            return 4;
        }

        
        return 0;
    }
}
