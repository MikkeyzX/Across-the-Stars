using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
   
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public GameObject GameOver;
    public GameObject Win;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    
    private void Update()
    {
         MyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        moveDirection.y = 0;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        var velocity = rb.velocity;
        velocity.y = 0;
        rb.velocity = velocity;

    }
    
    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("Enemy"))
        {
            GameOver.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
        if(other.transform.CompareTag("Winner"))
        {
            Win.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }
}
