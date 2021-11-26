using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour
{   
    public Rigidbody cloudRigidBody;

    //create speed
    public float cloudSpeed =  30f;

    // Start is called before the first frame update
    void Start()
    {
        cloudRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        int thrust = 10;

        //apply force to the cloud
        cloudRigidBody.AddForce(0,0, thrust * cloudSpeed);
    }
}
