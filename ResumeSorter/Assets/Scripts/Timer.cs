using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Timer
    public float time;
    private bool timerEnabled = false;
    public UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        timerEnabled = true;
        time = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerEnabled)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                uiManager.UpdateTimer(time);
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
