using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    private CharacterController controller;

    private float verticalVelocity;
    private float gravity = 14.0f;
    private float jumpForce = 10.0f;

	
	void Start () {
        controller = GetComponent<CharacterController>();
        
    }
	
	
	void Update () {
        movement();
        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
        controller.Move(moveVector * Time.deltaTime);

    }

    void movement()
    {
        float speed = 3f;
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        Vector3 moveVectorMovement = new Vector3(x, 0, z);
        controller.Move(moveVectorMovement);
    }
}
