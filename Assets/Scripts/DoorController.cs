using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int totalButtons = 3; 
    private int buttonsPressed = 0; 

    private void Start()
    {
       
    }

    public void ButtonPressed()
    {
        buttonsPressed++;
        Debug.Log($"Button pressed. {buttonsPressed}/{totalButtons} buttons activated.");

        if (buttonsPressed >= totalButtons)
        {
            UnlockDoor();
        }
    }

    private void UnlockDoor()
    {
        Debug.Log("All buttons pressed! Door is unlocked.");

       
        {
            
            Destroy(gameObject);
        }
    }
}