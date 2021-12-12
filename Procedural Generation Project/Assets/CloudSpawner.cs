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
        Vector3 spawnPosition = new Vector3(transform.position.x + Random.Range(-200f, 200f), transform.position.y + Random.Range(-5f, 50f), transform.position.z + Random.Range(-30f, 30f));
        GameObject newCloud = Instantiate (cloud, spawnPosition, transform.rotation);
        newCloud.tag = "Cloud";

        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
