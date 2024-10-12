using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceManager : MonoBehaviour
{
    public TMP_Text timerText, dayText;

    public float timeLeft = 1;
    public bool timerIsRunning = false;

    void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        DisplayTime(timeLeft);
        if (timerIsRunning)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time ran out");
                timeLeft = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = $"{minutes}.{seconds}";
    }

    void SetDay(float dayTime)
    {
        int daysInt = GameObject.Find("GameManager").GetComponent<GameManager>().days;
        dayText.text = $"{daysInt}";
    }
}
