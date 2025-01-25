using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_FlashlightMovement : MonoBehaviour
{
    public Transform orientation;

    public float sensX;
    public float sensY;
    private float xRotation = 0f;
    private float yRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX * 20000;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY * 20000;

        yRotation += mouseX;

        xRotation -= mouseY;

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
