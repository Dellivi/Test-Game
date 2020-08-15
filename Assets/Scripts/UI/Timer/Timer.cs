using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timer;

    private static float time;
    public static float Time { get => time; set => time = value; }

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        StartTimer();
    }

    void StartTimer()
    {
        if (!UIManager.IsGameStopped && Time >= 0 && !UIManager.IsGamePaused)
        {
            Time -= UnityEngine.Time.deltaTime;
            var timeInt = (int)Time;

            Debug.Log("TimerCount: " + timeInt);
            timer.SetText(timeInt.ToString());

            UnityEngine.Time.timeScale = 1; //  Normal time
        }
        else
        {
            
            UIManager.IsGameStopped = true;  // Stop game if Time = 0

            if(UIManager.IsGameStopped && Time <= 0)
            {
                MeteorSpawn.StopSpawning = true;
            }
        }
    }     
   
}
