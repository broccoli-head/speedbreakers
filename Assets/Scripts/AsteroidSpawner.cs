using Unity.VisualScripting;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnInterval;
    public Vector2 xSpawnRange;
    public float spawnY;
    public float objectSpeed;
    public float despawnY;

    private float timer;
    private bool lastNegative = false;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0;
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        float x = Random.Range(xSpawnRange.x, xSpawnRange.y);

        if (lastNegative)
        {
            x = -x;
            lastNegative = false;
        }
        else lastNegative = true;
     
        GameObject obj = Instantiate(
            prefab,
            new Vector3(x, spawnY, 0),
            Quaternion.identity
        );

        obj.GetOrAddComponent<SpriteRenderer>().sortingOrder = 1;

        MoveAsteroid mover = obj.AddComponent<MoveAsteroid>();
        mover.speed = objectSpeed;
        mover.despawnY = despawnY;
    }
}
