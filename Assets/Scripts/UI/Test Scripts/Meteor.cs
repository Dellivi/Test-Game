using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Meteor : MonoBehaviour, IMeteor
{
    [SerializeField]
    private Vector2 dir;
    private float speed;


    public Vector2 Dir { get => dir; set => dir = value; }
    public float Speed { get => speed; set => speed = value; }

    private void Start()
    {
        // Random number 1 or -1;
        //var result = Random.Range(0, 2) * 2 - 1; 
        //Dir = new Vector2(result, 0);
        
        speed = Random.Range(1f,4f);
    }


    private void FixedUpdate()
    {
        Move();
    }


    //-------------------------------------------------------------------------------------------
    // Public methods
    //-------------------------------------------------------------------------------------------
    public void Move()
    {
        if (!UIManager.IsGameStopped && !UIManager.IsGamePaused)
        {
            transform.Translate(Speed * Dir * Time.fixedDeltaTime);
        }
    }
}
