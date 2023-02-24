using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hour : MonoBehaviour
{
    public GameObject hour;
    public GameObject minute;
    public GameObject second;
    DateTime localTime = DateTime.Now;
    string oldSeconds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        string seconds = System.DateTime.UtcNow.ToString("ss");
        if (seconds != oldSeconds)
        {
            UpdateTimer();
        }
        oldSeconds = seconds;
    }

    private void UpdateTimer()
    {
        int secondsInt = int.Parse(System.DateTime.UtcNow.ToString("ss"));
        int minutesInt = int.Parse(System.DateTime.UtcNow.ToString("mm"));
        int hoursInt = int.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("hh"));
        if (hoursInt == 12) { hoursInt = 0; }
        print("H: " + hoursInt + " M: " + minutesInt + " S: " + secondsInt);
        iTween.RotateTo(second, iTween.Hash("x", secondsInt * 6 , "time", 1, "easetype", "easeOutQuint"));
        iTween.RotateTo(minute, iTween.Hash("x", minutesInt * 6, "time", 1, "easetype", "easeOutElastic"));
        float hourDistance = (float)(minutesInt) / 60f;
        iTween.RotateTo(hour, iTween.Hash("x", (hoursInt + hourDistance) * 360/12, "time", 1, "easetype", "easeOutQuint"));

    }
}
