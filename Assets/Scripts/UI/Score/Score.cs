using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI score;
    private static int startScore;
    public static int StartScore { get => startScore; set => startScore = value; }

    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if(StartScore >= 0)
        {
            ShowScore();

        }
        else
        {
            UIManager.IsGameStopped = true;
            MeteorSpawn.StopSpawning = true;
        } 
    }

    void ShowScore()
    {
        score.SetText(StartScore.ToString());
    }

}
