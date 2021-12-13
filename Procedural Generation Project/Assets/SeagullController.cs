using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullController : MonoBehaviour
{  
    Vector3 nextWaypoint;
    public float smoothTime = 3F;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(10,246), Random.Range(10, 15), Random.Range(10, 246));
        nextWaypoint = new Vector3(Random.Range(10,246), Random.Range(10, 15), Random.Range(10, 246));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 toNext = nextWaypoint - transform.position;
        float dist = toNext.magnitude;
        Vector3 direction = toNext / dist;
        transform.position = Vector3.SmoothDamp(transform.position, nextWaypoint, ref velocity, smoothTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(toNext, Vector3.up), 180 * Time.deltaTime);

        if (dist < 1)
        {
            nextWaypoint = new Vector3(Random.Range(0,256), Random.Range(40, 50), Random.Range(0, 256));
        }
    }
}
