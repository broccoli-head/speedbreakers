using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speed = 2f;
    private float backgroundHeight;

    private Transform bg1;
    private Transform bg2;

    void Start()
    {
        bg1 = transform.GetChild(0);
        bg2 = transform.GetChild(1);
        backgroundHeight = bg1.GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        bg1.position += Vector3.down * speed * Time.deltaTime;
        bg2.position += Vector3.down * speed * Time.deltaTime;

        if (bg1.position.y < -backgroundHeight)
            bg1.position = new Vector3(bg1.position.x, bg2.position.y + backgroundHeight, bg1.position.z);
   
        if (bg2.position.y < -backgroundHeight)
            bg2.position = new Vector3(bg2.position.x, bg1.position.y + backgroundHeight, bg2.position.z);
    }
}
