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

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
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
