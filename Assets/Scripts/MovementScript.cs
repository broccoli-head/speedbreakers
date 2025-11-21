using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float acceleration = 50f;
    public float maxSpeed = 10f;
    public float damping = 5f;

    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;

    private Rigidbody2D rb;
    private Camera cam;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    void FixedUpdate()
    {
        Vector2 force = Vector2.zero;

        if (Input.GetKey(up))
            force += (Vector2)transform.up;

        if (Input.GetKey(down))
            force -= (Vector2)transform.up;

        if (Input.GetKey(left))
            force -= (Vector2)transform.right;

        if (Input.GetKey(right))
            force += (Vector2)transform.right;

        if (force != Vector2.zero)
        {
            rb.AddForce(force.normalized * acceleration);

            if (rb.linearVelocity.magnitude > maxSpeed)
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, Vector2.zero, Time.fixedDeltaTime * damping);
        }

        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);

        viewPos.x = Mathf.Clamp(viewPos.x, 0f, 1f);
        viewPos.y = Mathf.Clamp(viewPos.y, 0f, 1f);

        viewPos.z = Mathf.Abs(cam.transform.position.z - transform.position.z);

        Vector3 worldPos = cam.ViewportToWorldPoint(viewPos);

        rb.position = worldPos;
    }
}
