using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasInGame : MonoBehaviour
{
    public TimerManager timerManager;
    public int levelTime;
    public Transform orders_grp;

    private void Start()
    {
        timerManager.TimerInit(levelTime);
    }

    public void OnSettingsPressed()
    {
        Instantiate(Resources.Load("Widgets/" + "Widget_PauseMenu") as GameObject).GetComponent<WidgetPauseMenu>();
    }
}
