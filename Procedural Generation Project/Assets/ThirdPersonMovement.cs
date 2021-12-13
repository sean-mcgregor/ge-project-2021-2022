using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;  // Character controller goes here
    public Transform cam;                   // Main camera referenced here
    public float speed = 6f;                // Player speed
    public float turnSmoothTime = 0.1f;     // Value for smooth turning
    float turnSmoothVelocity;               // Value for smooth turning
    public float gravity = -9.81f;          // Gravity strength value


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");  // Getting raw user directional input, returns value between 1f and -1f.
                                                            // 1f if you press "D" and -1f if you press "A"

        float vertical = Input.GetAxisRaw("Vertical");      // Getting raw user directional input, returns value between 1f and -1f.
                                                            // 1f if you press "W" and -1f if you press "S"

        // Saving direction to travel, noramlising it so as to prevent faster movement if user clicking more than one key
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // If direction to move exists
        if (direction.magnitude >= 0.1f)
        {
            // Calculating how much to turn character to face travel direction,
            // converting result from radians to degrees
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            // Turning smoothly instead of snapping
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Calculating direction we want to move in
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            
            // Move in direction
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        // Applying gravity to player
        controller.Move(new Vector3(0, gravity, 0) * Time.deltaTime);
    }
}
