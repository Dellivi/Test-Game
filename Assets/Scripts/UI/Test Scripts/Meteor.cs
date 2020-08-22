using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Meteor : MonoBehaviour, IMeteor
{

    //-------------------------------------------------------------------------------------------
    // Initializated fields / Private
    //-------------------------------------------------------------------------------------------
    [SerializeField]
    private Vector2 dir;
    private float speed;
    private int scoreAdd;


    //-------------------------------------------------------------------------------------------
    // Getters and Setters / Public
    //-------------------------------------------------------------------------------------------

    public Vector2 Dir { get => dir; set => dir = value; }
    public float Speed { get => speed; set => speed = value; }
    public int ScoreAdd { get => scoreAdd; set => scoreAdd = value; }

    private void Start()
    {
        // Random number 1 or -1;
        //var result = Random.Range(0, 2) * 2 - 1; 
        //Dir = new Vector2(result, 0);

        // Default scoreAdd
        ScoreAdd = 1; 
        
        speed = Random.Range(1f,4f);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnDestroy()
    {
        Score.StartScore += ScoreAdd;
    }



    //-------------------------------------------------------------------------------------------
    // Public methods
    //-------------------------------------------------------------------------------------------


    public void Move()
    {
        if (!GameManager.IsGameStopped && !GameManager.IsGamePaused)
        {
            transform.Translate(Speed * Dir * Time.fixedDeltaTime);
        }
    }
}
