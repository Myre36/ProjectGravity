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
    public GameObject gravityColliders;

    public Component[] highlights;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        highlights = gravityColliders.GetComponentsInChildren<GravityButtonsScript>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            gravityWheel.SetActive(true);
            gravityColliders.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 1.0f;
            
            foreach(GravityButtonsScript high in highlights)
            {
                high.DeactivateHighlight();
            }


            gravityWheel.SetActive(false);
            gravityColliders.SetActive(false);
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

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (GravityButtonsScript high in highlights)
            {
                high.DeactivateHighlight();
            }
            gravityWheel.SetActive(false);
            gravityColliders.SetActive(false);
        }
        
    }

    
}
