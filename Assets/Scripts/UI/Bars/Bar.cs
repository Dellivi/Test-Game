using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bar : MonoBehaviour
{
    public GameObject bars;
    public GameObject bonus;

    public Transform bonusSpawn;

    private static bool isReset;

    private  int barCount;

    private static Image[] barsArray;

    public static bool IsReset { get => isReset; set => isReset = value; }

    // Start is called before the first frame update
    void Start()
    {
        Image bar = bars.transform.Find("Panel").GetComponent<Image>();
        Image bar1 = bars.transform.Find("Panel 1").GetComponent<Image>();
        Image bar2 = bars.transform.Find("Panel 2").GetComponent<Image>();
        Image bar3 = bars.transform.Find("Panel 3").GetComponent<Image>();
        Image bar4 = bars.transform.Find("Panel 4").GetComponent<Image>();

        barsArray = new Image[]
        {
            bar,
            bar1,
            bar2,
            bar3,
            bar4,
        };   
    }

    private void Update()
    {
        if (MeteorManager.IsHit && barCount <= 5)  // if hit Meteor then change bar alpha
        {
            UpdateBar(1f);
            barCount += 1;
            MeteorManager.IsHit = false;
        }

        if (IsReset || barCount >= 5)  // Change alpha if miss target or hit 5 times
        {
            if (barCount >= 5)
            {   
                SpawnBonus();
            }

            StartCoroutine(ResetBar());

            barCount = 0;
            IsReset = false;
            MeteorManager.IsHit = false;
        }
        else StopCoroutine(ResetBar());
            
    }

    //-------------------------------------------------------------------------------------------
    // Public methods
    //-------------------------------------------------------------------------------------------

    public void UpdateBar(float alpha)
    {
        // Change Alpha in one of the Bars += 1 every click;
        var TempColor = barsArray[barCount].color;  
        TempColor.a = alpha;
        barsArray[barCount].color = TempColor;
    }

    public void SpawnBonus()
    {
        Vector3 vector = new Vector3(Random.Range(1f, 5f), Random.Range(1f, 5f), bonusSpawn.position.z);
        Instantiate(bonus, vector, Quaternion.identity);
    }

    //-------------------------------------------------------------------------------------------
    // IEnumerators
    //-------------------------------------------------------------------------------------------

    IEnumerator ResetBar()  //Change Alpha in every bars
    {
        for (int i = barCount - 1; i < barsArray.Length && i != -1; i--)
        {
            for (float ft = 1f; ft >= 0.3f; ft -= 0.7f)
            {
                var TempColor = barsArray[i].color;
                TempColor.a = ft;
                barsArray[i].color = TempColor;
                yield return new WaitForSeconds(.01f);
            } 
        } 
    }

    //-------------------------------------------------------------------------------------------
    // end
    //-------------------------------------------------------------------------------------------

}
