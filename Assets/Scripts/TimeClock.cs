////////////////////////////
// File: TimeClock.cs
// Author: Bradley Morrison
// Date: 05/01/2021

/* 
    a functioning clock with am/pm functionality. Also returns time in
    a neat string (07:00am).

    Can be customised by:
        -> timeInc - amount of minutes each tick jumps
        -> timeBreak - the time in real seconds between each tick
        -> timePause - time can be paused
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

                                                  
public class TimeClock : Game
{
    // time variables
    public float timeHour;     // current hour
    public float timeMin;      // current minute
    public string timeExt;     // am or pm
    // control variables
    public float timeBreak;    // time between each tick
    public float timeInc;      // time increment of each tick
    public bool timePause;     // should time be paused
    // reference variables
    public int tickCount;
    // events
    public event Action Ticked;
    public event Action Paused;

    private void Awake()
    {
        // initialising clock variables for HeroStall game
        // each day is 6am to midnight(18 hours || 1080 mins)
        // each day is to take 5mins realtime, therefore each tick is 0.2778s
        timeHour = 6;
        timeMin = 0;
        timeExt = "am";
        timeInc = 1; // 1
        timeBreak = 0.2778f; //0.2778f for 5min game
        timePause = false;
    }

    private void Start()
    {
        // start time
        StartCoroutine("timer");
    }

    // adds the increment value to the current time
    public void Tick()
    {
        // check that increment is less than an hour and pause is off
        if (timeInc <= 60.0f && !timePause)
        {
            // if not counting into next hour
            if (timeMin + timeInc < 60)
            {
                timeMin += timeInc;
            }
            else
            {
                // calculate how many minutes into new hour
                float distanceToNextHour = 60 - timeMin;
                timeMin = timeInc - distanceToNextHour;

                // check for am & pm flip
                if (timeHour == 11)
                {
                    if (timeExt == "am")
                        timeExt = "pm";
                    else
                        timeExt = "am";
                }

                // check for hour over 12
                if (timeHour == 12)
                    timeHour = 1;
                else
                    timeHour++;
            }

            tickCount++;
            Ticked(); // alert all subscribers
        }
    }

    public void PauseTime()
    {
        Paused(); // call pause event
        timePause = !timePause; // toggle bool
    }

    // returns time formatted into string (00:00am)
    public string TimeString()
    {
        // format leading 0's
        string strHour = timeHour.ToString();
        string strMin = timeMin.ToString();
        if (strHour.Length == 1) strHour = '0' + strHour;
        if (strMin.Length == 1) strMin = '0' + strMin;

        return  strHour + ":" + strMin + timeExt;
    }

    // coroutines

    // waits and then calls the Tick() function
    public IEnumerator timer()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(timeBreak);
            Tick();
        }
    }
}
