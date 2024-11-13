using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfHoleScript : MonoBehaviour
{
    

    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            door.GetComponent<PressurePlateDoor>().buttonsPressed++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            door.GetComponent<PressurePlateDoor>().buttonsPressed--;
        }
    }
}
