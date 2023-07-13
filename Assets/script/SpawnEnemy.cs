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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null && hit.collider.gameObject == objectPrefab)
            {
                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            }
            if (hit.collider != null && hit.collider.gameObject == objectPrefab2)
            {
                Instantiate(enemyPrefab2, spawnPoint.position, spawnPoint.rotation);
            }
            if (hit.collider != null && hit.collider.gameObject == objectPrefab3)
            {
                Instantiate(enemyPrefab3, spawnPoint.position, spawnPoint.rotation);
            }
            if (hit.collider != null && hit.collider.gameObject == objectPrefab4)
            {
                Instantiate(enemyPrefab4, spawnPoint.position, spawnPoint.rotation);
            }
            if (hit.collider != null && hit.collider.gameObject == objectPrefab5)
            {
                Instantiate(enemyPrefab5, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}
