using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{   
    public GameObject cloud;
    public float spawnTime;
    public float spawnDelay;
    public bool stopSpawning;
    public GameObject[] activeClouds;

    public int maxClouds = 6;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("SpawnObject", spawnTime, spawnDelay);
    }

    void Update() {
        
        activeClouds = GameObject.FindGameObjectsWithTag("Cloud");

        if(activeClouds.Length > maxClouds){

            Destroy(activeClouds[0]);
        }
    }
    

    // Update is called once per frame
    public void SpawnObject()
    {
        GameObject newCloud = Instantiate (cloud, transform.position, transform.rotation);
        newCloud.tag = "Cloud";

        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
