using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float turnSpeed = 200f;

    public GameObject[] spawnPoints;

    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode backKey = KeyCode.S;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        int randomIndex = Random.Range(0, spawnPoints.Length);
        transform.position = spawnPoints[randomIndex].transform.position;
        Debug.Log(this + " spawned at spawn point: " + (randomIndex + 1));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Movement Controls
        float moveInput = 0;
        float turnInput = 0;

        moveInput = moveVert();

        Vector3 moveDirection = transform.forward * moveInput * moveSpeed * Time.fixedDeltaTime;
    
        rb.MovePosition(rb.position + moveDirection);

        turnInput = rotateCheck();

        Quaternion turnRotation = Quaternion.Euler(0f, turnInput * turnSpeed * Time.fixedDeltaTime, 0f);

        rb.MoveRotation(rb.rotation * turnRotation);
    }

    public int moveVert()
    {
        if (Input.GetKey(forwardKey))
        {
            return 1;
        }
        else if (Input.GetKey(backKey))
        {
            return -1;
        }
        
        return 0;
    }

    public int rotateCheck()
    {
        if (Input.GetKey(leftKey))
        {
            return -1;
        }
        else if (Input.GetKey(rightKey))
        {
            return 1;
        }
        
        return 0;
    }
}
