using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    [SerializeField]
    private Text timer;
    
    public void UpdateTimer(float time)
    {
        // format licznika w postaci 00:00
        TimeSpan span = TimeSpan.FromSeconds(time);
        timer.text = string.Format("{0:d2}:{1:d2}", span.Minutes, span.Seconds);
    }
}
