using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextChunk : MonoBehaviour
{
    public GameObject lastLevel;
    public GameObject nextLevel;

    public GameObject lastHallway;
    public GameObject nextHallway;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            lastLevel.SetActive(false);
            nextLevel.SetActive(true);
            lastHallway.SetActive(false);
            nextHallway.SetActive(true);
        }
    }
}
