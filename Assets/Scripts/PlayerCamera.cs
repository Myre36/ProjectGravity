using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform headObject;

    public Transform player;

    private float xRotation;

    public GameObject gravityWheel;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            gravityWheel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            gravityWheel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            //Get mouse input
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            Vector3 headRotation = headObject.localRotation.eulerAngles;

            xRotation += -mouseY;
            xRotation = Mathf.Clamp(xRotation, -85f, 85f);
            headRotation.x = xRotation;
            headObject.localRotation = Quaternion.Euler(headRotation);

            player.transform.Rotate(Vector3.up, mouseX, Space.Self);
        }

        
    }

    
}
