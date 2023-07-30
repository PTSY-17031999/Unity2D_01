using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    // Tao singleton
    public static TowerSpawner Instance;
    private void Awake()
    {
        Instance = this;
    }

    public Tower towerPrefab;

    public void SpawnTower(Vector2 position)
    {
        Tower tower = Instantiate(towerPrefab);
        tower.transform.position = position;
    }
}