using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Round
    string roundPrefix = "Round ";
    [SerializeField] Text roundTxt;

    // Timer
    string timerPrefix = "Time Left:";
    [SerializeField] Text timerTxt;

    // Resume
    [SerializeField] Image resumeObj;

    // Update UI of Round
    public void UpdateRound(int round)
    {
        round++;
        roundTxt.text = roundPrefix + round;
    }

    // Update UI of Timer
    public void UpdateTimer(float currentTime)
    {
        int time = (int) Math.Floor(currentTime);
        timerTxt.text = string.Format("{0} {1}", timerPrefix, time.ToString());
        Debug.Log(string.Format("{0} {1}", timerPrefix, time.ToString()));
    }

    // Update Resume
    public void UpdateResume(Sprite resume)
    {
        resumeObj.GetComponent<Image>().sprite = resume;
    }
}
