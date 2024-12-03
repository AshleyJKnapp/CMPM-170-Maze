using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerMovementScript : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float playerSpeed = 5.0f;
    public Camera playerCamera;
    private Transform cam;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = playerCamera.transform;
        // playerCamera = GetComponentInChildren<Camera>()
    }

    // void FixedUpdate()
    // {
    //     // if (playerVelocity.y < 0)
    //     // {
    //     //     playerVelocity.y = 0f;
    //     // }

    //     // Vector3 move = new Vector3(0, 0, 0);
    //     // // Forward Movement
    //     // if (Input.GetKey("w")) {
    //     //     Debug.Log("Move Forward");
    //     //     move = (move + Vector3.forward).normalized;
    //     // }
    //     // // Backward Movement
    //     // if (Input.GetKey("s")) {
    //     //     Debug.Log("Move Backward");
    //     //     move = (move + Vector3.back).normalized;
    //     // }
    //     // // Left Movement
    //     // if (Input.GetKey("a")) {
    //     //     Debug.Log("Move Left");
    //     //     move = (move + Vector3.left).normalized;
    //     // }
    //     // // Right Movement
    //     // if (Input.GetKey("d")) {
    //     //     Debug.Log("Move Right");
    //     //     move = (move + Vector3.right).normalized;
    //     // }

    //     // controller.Move(move * Time.deltaTime * playerSpeed);

    //     Vector3 verticalAxis = new Vector3(0, 0, 0);
    //     // Forward Movement
    //     if (Input.GetKey("w")) {
    //         Debug.Log("Move Forward");
    //         verticalAxis = (verticalAxis + Vector3.forward).normalized;
    //     }
    //     // Backward Movement
    //     if (Input.GetKey("s")) {
    //         Debug.Log("Move Backward");
    //         verticalAxis = (verticalAxis + Vector3.back).normalized;
    //     }

    //     Vector3 horizontalAxis = new Vector3(0, 0, 0);
    //     // Left Movement
    //     if (Input.GetKey("a")) {
    //         Debug.Log("Move Left");
    //         horizontalAxis = (horizontalAxis + Vector3.left).normalized;
    //     }
    //     // Right Movement
    //     if (Input.GetKey("d")) {
    //         Debug.Log("Move Right");
    //         horizontalAxis = (horizontalAxis + Vector3.right).normalized;
    //     }


    //     //camera forward and right vectors:
    //     var camForward = playerCamera.transform.forward;
    //     var camRight = playerCamera.transform.right;

    //     //project forward and right vectors on the horizontal plane (y = 0)
    //     Debug.Log("Init Cam " + camForward);
    //     camForward = Vector3.Scale(camForward, new Vector3(1, 0 ,1));
    //     camRight = Vector3.Scale(camRight, new Vector3(1, 0 ,1));
    //     camForward.Normalize();
    //     camRight.Normalize();

    //     //this is the direction in the world space we want to move:
    //     Vector3 desiredMoveDirection = Vector3.Scale(verticalAxis, camForward) + Vector3.Scale(horizontalAxis, camRight);
    //     Debug.Log("Moving by "+desiredMoveDirection);
    //     //now we can apply the movement:
    //     controller.Move(desiredMoveDirection * playerSpeed * Time.deltaTime);

    //     // if (move != Vector3.zero)
    //     // {
    //     //     gameObject.transform.forward = move;
    //     // }

    //     // controller.Move(playerVelocity * Time.deltaTime);
    // }

    void FixedUpdate()
    {
        Vector3 verticalAxis = new Vector3(0, 0, 0);
        // Forward Movement
        if (Input.GetKey("w")) {
            Debug.Log("Move Forward");
            verticalAxis = (verticalAxis + Vector3.forward).normalized;
        }
        // Backward Movement
        if (Input.GetKey("s")) {
            Debug.Log("Move Backward");
            verticalAxis = (verticalAxis + Vector3.back).normalized;
        }

        Vector3 horizontalAxis = new Vector3(0, 0, 0);
        // Left Movement
        if (Input.GetKey("a")) {
            Debug.Log("Move Left");
            horizontalAxis = (horizontalAxis + Vector3.left).normalized;
        }
        // Right Movement
        if (Input.GetKey("d")) {
            Debug.Log("Move Right");
            horizontalAxis = (horizontalAxis + Vector3.right).normalized;
        }
        
        // var movementSpeed = new Vector3(horizontalAxis * playerSpeed, 0, verticalAxis * playerSpeed);
        var movementSpeed = Vector3.Scale((horizontalAxis * playerSpeed), (verticalAxis * playerSpeed)).normalized;

        transform.position += transform.TransformDirection(movementSpeed);
        controller.Move(movementSpeed);


        var camY = cam.eulerAngles.y;
        var rot = new Vector3(0, camY, 0);
        var rotation = Quaternion.Euler(rot);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 180);
    }

    // void LateUpdate()
    // {
        
    // }

    // void CalculatePlayerSpeed()
    // {
        

    //     side = Input.GetAxis(“HorizontalK”)+Input.GetAxis(“HorizontalJ”);
    //     fwd = Input.GetAxis(“VerticalK”)+Input.GetAxis(“VerticalJ”);
    // }

    // void Move()
    // {
    //     transform.position += transform.TransformDirection(movementSpeed);
    // }

    // Update is called once per frame
    // void FixedUpdate()
    // {
    //     // Movement Controls
    //     float FBInput = Input.GetAxis("Vertical");
    //     float LRInput = Input.GetAxis("Horizontal");

    //         // Forward/Backward
    //     Vector3 moveDirection = transform.forward * FBInput;
    

    //     Vector3 LRDirection = transform.right * LRInput;
    
    //     Vector3 totalDirection = (moveDirection + LRDirection).normalized * moveSpeed * Time.fixedDeltaTime;

    //     rb.MovePosition(rb.position + totalDirection);
    //     // Move Egg along with this object 
    //     // (when implementing raycast movement, do all the raycast stuff to the egg as well)
    //     if (holdingEgg){heldEggRb.MovePosition(heldEggRb.position + totalDirection);}

        
    // }
}
