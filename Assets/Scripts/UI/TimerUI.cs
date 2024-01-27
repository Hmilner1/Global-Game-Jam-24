using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static LevelTrigger;

public class TimerUI : MonoBehaviour
{
    #region Events
    public delegate void TimerEnd();
    public static event TimerEnd OnTimerEnd;
    #endregion

    private float timeRemaining;
    private bool timerStarted;
    [SerializeField]
    private float totalTime = 6f;
    [SerializeField]
    private TMP_Text gameTimer;

    private void OnEnable()
    {
        LevelTrigger.onLevelTriggered += TimerStart;
    }

    private void OnDisable()
    {
        LevelTrigger.onLevelTriggered -= TimerStart;
    }

    private void Start()
    {

        timeRemaining = totalTime;
    }

    private void FixedUpdate()
    {
        if (timerStarted) { TimerCountDown(); }
    }

    private void TimerStart()
    {
        timeRemaining = totalTime;
        timerStarted = true;
    }

    private void TimerCountDown()
    {
        if (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;
            TimerUIUpdate();
        }
        else
        {
            string timeString = "00:00";

            gameTimer.text = timeString;
            OnTimerEnd?.Invoke();
        }
    }

    private void TimerUIUpdate()
    {
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);
            string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

            gameTimer.text = timeString;
        }
    }
}
