using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    private float timeInterval;
    Image timerBar;

    private float timeElapsed;
    private bool timerIsSet;



    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0f;

        timerBar = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeInterval)
        {
            timeElapsed = timeInterval;
        }
        timerBar.fillAmount = (timeElapsed / timeInterval);

        if (timeElapsed == timeInterval && timerIsSet)
        {
            ringTimer();
        }

    }
    public void setTimer(float time)
    {
        timeInterval = time;
        timerIsSet = true;
    }

    private void ringTimer()
    {
        print("Time's up!");
    }

    public float getTimeElapsed()
    {
        return timeElapsed;
    }
}
