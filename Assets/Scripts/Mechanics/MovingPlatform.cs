using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;
    [SerializeField] [Range(0.1f, 2f)]
    private float speed = 2f;
    private int index = 0;  // indeks aktualnego punktu
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, speed * Time.deltaTime);
        rb.MovePosition(Vector3.MoveTowards(rb.position, waypoints[index].position, speed * Time.fixedDeltaTime));

        if (Vector3.Distance(rb.position, waypoints[index].position) < 0.1f)
            index = (index + 1) % waypoints.Length;
    }

}
