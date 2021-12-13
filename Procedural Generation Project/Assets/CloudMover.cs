using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour
{   
    public Rigidbody cloudRigidBody;    // Rigid body for cloud physics and force application
    public float cloudSpeed =  4f;      // Speed of cloud


    // Start is called once when Play is pressed
    void Start()
    {
        cloudRigidBody = GetComponent<Rigidbody>(); // Get rigid body component
    }


    // Update is called once per frame
    void Update()
    {
        int thrust = 10;

        cloudRigidBody.AddForce(0,0, -thrust * cloudSpeed); //apply force to the cloud
    }
}
