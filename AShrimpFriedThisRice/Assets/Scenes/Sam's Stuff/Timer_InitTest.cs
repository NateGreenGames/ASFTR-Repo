using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer_InitTest : MonoBehaviour
{
    public TimerManager timerManager;

    private void Start()
    {
        Debug.Log(timerManager);
        timerManager.TimerInit(100);
    }
}
