using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullController : MonoBehaviour
{  
    Vector3 nextWaypoint;                       // Seagull travels toward this point
    public float smoothTime = 3F;               // Seagull length of travel to point
    private Vector3 velocity = Vector3.zero;    // Vector3 accessed by smoothTime function


    // Start is called once when Play is pressed
    void Start()
    {
        // Spawns the seagull in random location within 256x256 grid
        // and generates the first waypoint for it to travel toward
        transform.position = new Vector3(Random.Range(10,246), Random.Range(10, 15), Random.Range(10, 246));
        nextWaypoint = new Vector3(Random.Range(10,246), Random.Range(10, 15), Random.Range(10, 246));
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;       // Gets Vector3 of current seagull position
        Vector3 toNext = nextWaypoint - currentPosition;    // Gets the distance to next location individually on all axes
        float dist = toNext.magnitude;                      // Converts distance from Vector3 to a float and to one precise length

        // These lines alter the position of the seagull frame by frame
        // and slowly rotate the seagull to face next waypoint, avoiding 
        // instant snapping of rotation
        transform.position = Vector3.SmoothDamp(currentPosition, nextWaypoint, ref velocity, smoothTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(toNext, Vector3.up), 180 * Time.deltaTime);

        // If the seagull has reached the waypoint, generate new waypoint for it to aim toward
        if (dist < 1)
        {
            nextWaypoint = new Vector3(Random.Range(0,256), Random.Range(40, 50), Random.Range(0, 256));
        }
    }
}
