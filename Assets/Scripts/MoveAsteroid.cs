using UnityEngine;

public class MoveAsteroid : MonoBehaviour
{
    public float speed = 1.5f;
    public float despawnY = -6f;

    private float rotationSpeed;

    void Start()
    {
        bool negativeRotation = Random.value < 0.5f;

        if (negativeRotation)
            rotationSpeed = Random.Range(-30f, -10f);
        else
            rotationSpeed = Random.Range(10f, 30f);
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        if (transform.position.y < despawnY)
            Destroy(gameObject);
    }
}
