using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;
    [SerializeField] [Range(0.1f, 2.5f)]
    private float speed = 2f;
    private int index = 0;  // indeks aktualnego punktu

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[index].position) < 0.1f)
            index = (index + 1) % waypoints.Length;
    }

}
