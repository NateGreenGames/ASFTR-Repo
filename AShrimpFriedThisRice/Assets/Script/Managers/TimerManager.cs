using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float currentTimer;
    public int startingTime;
    [SerializeField] TextMeshProUGUI timerNumbers;
    public Slider timerBar;

    public void TimerInit(int _startingTime)
    {
        currentTimer = _startingTime;
        timerBar.maxValue = currentTimer;
        Debug.Log(currentTimer);
        StartCoroutine(StartLevelTimer());
    }

    public IEnumerator StartLevelTimer()
    {
        while (currentTimer > 0)
        {
            currentTimer -= 1 * Time.deltaTime;
            timerNumbers.text = currentTimer.ToString("0");
            timerBar.value = currentTimer;
            yield return "success";
        }
        Debug.Log("Error LOL");
        yield return null;
    }
}
