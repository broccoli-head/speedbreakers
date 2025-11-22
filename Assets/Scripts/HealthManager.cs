using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int hitPoints;
    public Slider healthSlider;
    public float smoothSpeed;

    private float targetHealth;
    private Renderer renderer;

    void Start()
    {
        targetHealth = hitPoints;
        healthSlider.maxValue = hitPoints;
        healthSlider.value = hitPoints;
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        healthSlider.value = Mathf.Lerp(healthSlider.value, targetHealth, Time.deltaTime * smoothSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            hitPoints--;
            targetHealth = hitPoints;
            Debug.Log("Hit Points: " + hitPoints);
            if (hitPoints <= 0)
            {
                if(renderer != null)
                    renderer.enabled = false;
                Invoke("Explode", 2f);
            }
        }
    }

    void Explode()
    {
        Destroy(gameObject);
    }
}
