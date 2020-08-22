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

    //-------------------------------------------------------------------------------------------
    // Methods
    //-------------------------------------------------------------------------------------------

    void StartTimer()
    {
        if (!GameManager.IsGameStopped && Time >= 0 && !GameManager.IsGamePaused)
        {
            Time -= UnityEngine.Time.deltaTime;
            var timeInt = (int)Time;

            timer.SetText(timeInt.ToString());
            //  Normal time
            UnityEngine.Time.timeScale = 1; 
        }
        else
        {
            // Stop game if Time = 0  
            GameManager.IsGameStopped = true;  

            if(GameManager.IsGameStopped && Time <= 0)
            {
                MeteorSpawn.StopSpawning = true;
            }
        }
    }

    //-------------------------------------------------------------------------------------------
    // end
    //-------------------------------------------------------------------------------------------

}
