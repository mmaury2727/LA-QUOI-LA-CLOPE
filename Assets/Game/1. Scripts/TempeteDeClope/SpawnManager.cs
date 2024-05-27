using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject clope;
    private Manager manager;
    private float ySpawn = 13.0f;
    public float xSpawnRange = 3.5f;
    private float zSpawn = -0.35f;
    private int count = 0;
    public float clopeSpawnTime = 0.8f; // Randomize
    public float startDelay = 0.5f;


    void Start() {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    // Manager controls when objects start and stop spawning
    public void StartSpawning() 
    {
        InvokeRepeating("SpawnClope", startDelay, clopeSpawnTime);
    }

    public void StopSpawning()
    {
        CancelInvoke();
    }

    void SpawnClope() 
    {
        GameObject newClope;
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomRotX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomRotY = Random.Range(-xSpawnRange, xSpawnRange);
        Vector3 spawnPos = new Vector3(randomX, ySpawn, zSpawn);
        Quaternion spawnRot = new Quaternion(randomRotX, randomRotY, 0, 90);
        if (count < manager.scoreToWin)
        {
            newClope = Instantiate(clope, spawnPos, spawnRot);
            newClope.transform.parent = transform;
        }
        count++;
    }

}
