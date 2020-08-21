using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    [Header("Спавн позиция: ")]
    [SerializeField]  private Transform spawnPos;

    [Header("Объект спавна: ")]
    [SerializeField]  private  GameObject meteor;

    private static bool stopSpawning = false;
    private float spawnTime;
    private float spawnDelay;


    public static bool StopSpawning { get => stopSpawning; set => stopSpawning = value; }

    private void Start()
    {

        spawnTime = Random.Range(1f, 3f);
        spawnDelay = Random.Range(0.5f, 6f);

        StopSpawning = false;

        InvokeRepeating("Spawn", spawnTime, spawnDelay);
    }

    private void Update()
    {
        if (StopSpawning)
        {
            CancelInvoke("Spawn");

        }
    }

    //-------------------------------------------------------------------------------------------
    // Public methods
    //-------------------------------------------------------------------------------------------

    void Spawn()
    {
        Vector3 spawnVector = new Vector3(spawnPos.position.x, Random.Range(-3f, 4f), spawnPos.position.z);
        Instantiate( meteor, spawnVector, Quaternion.identity);
        
        
    }
}
