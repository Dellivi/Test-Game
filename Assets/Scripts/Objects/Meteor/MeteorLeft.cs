using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorLeft : MonoBehaviour
{
    private float speed;
    private Vector2 dir;
    public float Speed { get => speed; set => speed = value; }
    public Vector2 Dir { get => dir; set => dir = value; }

    private void Start()
    {
        Dir = new Vector2(1, 0);
        Speed = Random.Range(2f, 6f);
    }

    private void FixedUpdate()
    {
        if(!UIManager.IsGameStopped && !UIManager.IsGamePaused)
        {
            transform.Translate(Speed * Dir * Time.fixedDeltaTime);
        }
    }
}
