using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    private timer Timer;

    private List<bool> timerFlags = new List<bool> { };
    private float nextTimerMark;
    private float nextTimerMarkIndex;


    public List<float> timerMarks; //totalBoxSpawns + totalBoxRequests should be equal to the size of timerMarks - 1
    public int totalBoxSpawns;
    public int totalBoxRequests;

    private boxManager bm;
    private requestManager rm;

    

    // Start is called before the first frame update
    void Start()
    {
        Timer = this.GetComponentInChildren<timer>();
        setupTimerFlags();
        Timer.setTimer(timerMarks[timerMarks.Count - 1]);

        nextTimerMark = timerMarks[0];

        bm = GetComponentInChildren<boxManager>();
        rm = GetComponentInChildren<requestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.getTimeElapsed() >= nextTimerMark)
        {
            if (nextTimerMarkIndex < totalBoxSpawns)
            {
                bm.spawnBox();
                manageTimerFlags();
            }
            else if (nextTimerMarkIndex < totalBoxSpawns + totalBoxRequests)
            {
                rm.requestBox();
                manageTimerFlags();
            }
            
        }
    }

    private void setupTimerFlags()
    {
        foreach (float mark in timerMarks)
        {
            timerFlags.Add(false);
        }
        nextTimerMarkIndex = 0;
    }

    private void manageTimerFlags()
    {
        int timerMarkIndex = 0;
        foreach (float mark in timerMarks)
        {
            if (mark == nextTimerMark)
            {
                break;
            }
            timerMarkIndex += 1;
        }
        timerFlags[timerMarkIndex] = true;

        nextTimerMark = timerMarks[timerMarkIndex + 1];
        nextTimerMarkIndex += 1;
    }
}
