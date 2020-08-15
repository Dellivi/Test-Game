using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MeteorManager : MonoBehaviour
{

    public GameObject explode;

    private static bool isHit;
    public static bool IsHit { get => isHit; set => isHit = value; }

    // Start is called before the first frame update
    void Start()
    {
        IsHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!UIManager.IsGameStopped && !UIManager.IsGamePaused)  // Stop any action if game stop
        {
            OnClick();
        } 
    }

    void OnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Meteor"))
                {
                    IsHit = true;
                    Score.StartScore += 1;  // Change score in UIManager

                    Destroy(hit.collider.gameObject);
                    Instantiate(explode, hit.transform.position, Quaternion.identity); // Instantiate explode
                }
            }
            else // if hit other
            {
                IsHit = false;
                Bar.IsReset = true;  // if hit other reset the bars
            }
        }
    }
   
}




