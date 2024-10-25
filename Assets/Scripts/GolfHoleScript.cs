using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfHoleScript : MonoBehaviour
{
    public bool ballInHole;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GolfBall"))
        {
            ballInHole = true;
        }
    }
}
