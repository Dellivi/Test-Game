using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour
{
    private ParticleSystem ps;
    public GameObject explode;

    private void Start()
    {
       ps = explode.transform.Find("PS_Fire_GLOW").GetComponent<ParticleSystem>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!ps.IsAlive())
        {
            Destroy(explode);
        }
    }
}
