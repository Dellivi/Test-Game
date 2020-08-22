using UnityEngine;
using System.Collections;

public class Bonus_Spawn : MonoBehaviour
{

    public GameObject explode;
    public GameObject bonus;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Bonus"))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }

       
    }

    private void OnDestroy()
    {
        Timer.Time += 3f;
        Instantiate(explode, bonus.transform.position, Quaternion.identity);
    }
}
