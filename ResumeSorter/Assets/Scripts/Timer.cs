using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Timer
    float time;
    private bool timerEnabled = false;
    public UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        timerEnabled = true;
        time = 10f;
        InvokeRepeating("CountTimer", 0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void CountTimer()
    {
        if (timerEnabled)
        {
            if (time > 0)
            {
                uiManager.UpdateTimer(time);
                time -= 1;
            }
            else
            {
                Debug.Log("Time is UP!");
                time = 0;
                timerEnabled = false;
            }
        }
        
    }
}
