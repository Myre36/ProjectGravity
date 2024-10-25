using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public DoorController doorController; 

    private bool isPressed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPressed)
        {
            isPressed = true;
            doorController.ButtonPressed(); 
            Debug.Log("Button pressed!");
            
            GetComponent<Renderer>().material.color = Color.green;
        }
    }
}