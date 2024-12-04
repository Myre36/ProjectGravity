using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public DoorController doorController;

    public AudioSource audioButton;

    private bool isPressed = false;

    public bool isPlaying = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPressed)
        {
            isPressed = true;
            if (!isPlaying)
            {
                audioButton.Play();
                isPlaying = true;
            }
            //doorController.ButtonPressed();
            Debug.Log("Button pressed!");
            
            GetComponent<Renderer>().material.color = Color.green;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (audioButton.isPlaying)
        {
            isPlaying = false;
        }
        isPressed = false;
    }
}