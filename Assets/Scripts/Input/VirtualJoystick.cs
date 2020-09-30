using UnityEngine;

public class VirtualJoystick : MonoBehaviour
{
    private Vector2 pointA;
    private Vector2 pointB;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            pointA = Input.mousePosition;

        Debug.Log(pointA);

        if (Input.GetMouseButton(0))
        {
            pointB = Input.mousePosition;
            CalculateInput();
        }
    }

    private void CalculateInput()
    {
        Vector2 diff = pointB - pointA;
        Vector2 direction = Vector2.ClampMagnitude(diff, 1f);

        Controls.Horizontal = direction.x;
        Controls.Vertical = direction.y;
    }
}
