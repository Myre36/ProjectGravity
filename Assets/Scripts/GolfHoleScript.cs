using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfHoleScript : MonoBehaviour
{
    public bool ballInHole;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            ballInHole = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            ballInHole = false;
        }
    }
}
