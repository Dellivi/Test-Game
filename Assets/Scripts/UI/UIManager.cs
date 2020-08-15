using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Объект с изображением паузы: ")]
    public GameObject paused;
    public GameObject menu;

    [Header("Время Таймера: ")]
    [SerializeField]  private float time;

    [Header("Начальное количество очков: ")]
    [SerializeField]  private int startScore; 

    private enum Mode {GameStopped, GamePaused}
    private Mode mode;

    private static bool isGameStopped;
    private static bool isGamePaused;
    public static bool IsGameStopped { get => isGameStopped; set => isGameStopped = value; }
    public static bool IsGamePaused { get => isGamePaused; set => isGamePaused = value; }


    // Start is called before the first frame update
    void Awake()
    {
        IsGameStopped = false;
        IsGamePaused = false; 

        Timer.Time = time;
        Score.StartScore = startScore;

        menu.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  // Pause
        {
            
            IsGamePaused = !IsGamePaused;
            IsGameStopped = IsGamePaused;

            Time.timeScale = 0;

            paused.SetActive(IsGamePaused);
        }

        if(IsGameStopped && !IsGamePaused) // GameOver menu
        {
            menu.SetActive(IsGameStopped);
        } 
    }

}
