using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{   
    public GameObject cloud;            // Cloud prefab
    public float spawnTime = 3;         // Time between each cloud
    public float spawnDelay = 1;        // Time between start until first cloud spawned
    public bool stopSpawning;           // Turn on and off spawner
    public GameObject[] activeClouds;   // Array of clouds currently in scene
    public int maxClouds = 12;          // Maximum amount of clouds in scene

    
    // Start is called once when Play is pressed
    void Start()
    {
        InvokeRepeating ("SpawnObject",  spawnDelay, spawnTime); // Repeatedly spawn cloud object
    }


    // Update is called once per frame
    void Update()
    {
        activeClouds = GameObject.FindGameObjectsWithTag("Cloud");  // Get all clouds currently in scene

        // If there are more clouds than allowed
        if(activeClouds.Length > maxClouds)
        {
            Destroy(activeClouds[0]);   // Destroy oldest cloud, which is not visible to player
        }
    }
    

    // Spawn cloud object
    public void SpawnObject()
    {
        // Defining a random space in the vicinity of the spawner,
        // so that clouds appear natural and not uniform
        Vector3 spawnPosition = new Vector3(transform.position.x + Random.Range(-200f, 200f),
                                            transform.position.y + Random.Range(-5f, 50f),
                                            transform.position.z + Random.Range(-30f, 30f));

        // Instantiate new cloud using the position
        GameObject newCloud = Instantiate (cloud, spawnPosition, transform.rotation);
        newCloud.tag = "Cloud"; // Add Cloud tag to clouds

        // Turn off spawner
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
