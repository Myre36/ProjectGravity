using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfHoleScript : MonoBehaviour
{
    public GameObject door;

    public Material openMat;
    public Material closedMat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            door.GetComponent<PressurePlateDoor>().buttonsPressed++;
            GetComponent<Renderer>().material = openMat;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            door.GetComponent<PressurePlateDoor>().buttonsPressed--;
            GetComponent<Renderer>().material = closedMat;
        }
    }
}
