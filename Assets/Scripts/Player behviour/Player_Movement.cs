using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{
    public AudioSource DeathSound;
    public AudioSource Death2Sound;
    public AudioSource WalkingSound;
    public Slider slider;

    [Header("Movement")]
    public float moveSpeed;
    public float Stamina;
    public float SpeedBoost;
    public float SprintCooldown;

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
        SpeedBoost = 1;
        Stamina = 100;
    }
    
    private void Update()
    {
         MyInput();
    }

    private IEnumerator TimerFunc()
    {
        while (true)
        {
            if (SprintCooldown == 1)
            {
                yield return new WaitForSeconds(3);
                SprintCooldown = 0;
                yield break;
            }
        }

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
        if (Input.GetKey(KeyCode.LeftShift) && Stamina > 0)
        {
            if (Stamina > 1 && SprintCooldown == 0)
            {
                SpeedBoost = 1.5f;
            }
            Stamina -= 1;
            if (Stamina < 0)
            {
                Stamina = 0;
            }
        }
        else
        {
            if (Stamina < 100)
            {
                Stamina += 0.1f;
            }
            SpeedBoost = 1;
        }
        if (Stamina < 1)
        {
            SprintCooldown = 1;
            StartCoroutine(TimerFunc());
        }
        if (SprintCooldown == 0)
        {
            StopCoroutine(TimerFunc());
        }
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        moveDirection.y = 0;
        rb.AddForce(moveDirection.normalized * moveSpeed * SpeedBoost * 10f, ForceMode.Force);
        var velocity = rb.velocity;
        velocity.y = 0;
        rb.velocity = velocity;
        if (velocity.x == 0)
        {
            WalkingSound.Pause();
        }
        else
        {
            WalkingSound.UnPause();
        }
        slider.value = Stamina/100;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("Enemy"))
        {
            GameOver.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            DeathSound.Play();
            Death2Sound.Play();
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
