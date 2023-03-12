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
        currentTime += 1;

        timerTxt.text = string.Format("%s %f", timerPrefix, currentTime);
    }

    // Update Resume
    public void UpdateResume(Sprite resume)
    {
        resumeObj.GetComponent<Image>().sprite = resume;
    }
}
