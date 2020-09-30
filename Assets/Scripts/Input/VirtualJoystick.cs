using UnityEngine;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour
{
    [SerializeField]
    private Image threshold;
    [SerializeField]
    private Image stick;

    private Vector2 centerPoint;
    private bool active = false;

    private float Normalize(float value)
    {
        if (value > 0)
            return 1f;
        else if (value < 0)
            return -1f;
        else
            return value;
    }

    private void setState(bool isActive)
    {
        active = isActive;
        threshold.enabled = isActive;
        stick.enabled = isActive;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (Input.touchCount == 0)
            return;

        Touch t1 = Input.GetTouch(0);

        if (t1.position.x < Screen.width / 2)
        {
            switch (t1.phase)
            {
                case TouchPhase.Began:
                    threshold.transform.position = t1.position;
                    stick.transform.position = t1.position;
                    centerPoint = t1.position;

                    setState(true);
                    break;

                case TouchPhase.Stationary:
                case TouchPhase.Moved:
                    if (active)
                    {
                        Vector2 diff = t1.position - centerPoint;
                        Vector2 direction = Vector2.ClampMagnitude(diff, 200f);
                        stick.transform.position = centerPoint + direction;
                        CalculateInput(direction);
                    }
                    break;

                case TouchPhase.Ended:
                    setState(false);
                    break;
            }
        } 
        else if(t1.phase == TouchPhase.Began)
        {
            Controls.Jump = true;
        }

        if (Input.touchCount < 2)
            return;

        Touch t2 = Input.GetTouch(1);
        if(t2.position.x > Screen.width / 2 && t2.phase == TouchPhase.Began)
            Controls.Jump = true;
    }

    private void CalculateInput(Vector2 direction)
    {
        Controls.Horizontal = Normalize(direction.x);
        Controls.Vertical = Normalize(direction.y);
    }
}
