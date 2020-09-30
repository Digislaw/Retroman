//
//  Rozszerzenie sterowania Unity
//

using UnityEngine;

public static class Controls
{
    private static float horizontal;
    public static float Horizontal
    {
        get
        {
            float val = horizontal != 0f ? horizontal : Input.GetAxisRaw("Horizontal");
            horizontal = 0f;
            return val;
        }

        set
        {
            horizontal = Mathf.Clamp(value, -1f, 1f);
        }
    }

    private static float vertical;
    public static float Vertical
    {
        get
        {
            float val = vertical != 0f ? vertical : Input.GetAxisRaw("Vertical");
            vertical = 0f;
            return val;
        }

        set
        {
            vertical = Mathf.Clamp(value, -1f, 1f);
        }
    }
}
