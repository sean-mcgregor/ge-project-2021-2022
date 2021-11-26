using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{   
    public GameObject cloud;
    public float spawnTime;
    public float spawnDelay;
    public bool stopSpawning;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("SpawnObject", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    public void SpawnObject()
    {
        Instantiate (cloud, transform.position, transform.rotation);

        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
