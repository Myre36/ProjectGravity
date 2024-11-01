using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerScript : MonoBehaviour
{
    public Transform checkPoint;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = checkPoint.position;
            collision.gameObject.GetComponent<GravityComponent>().gravityStatus = 0;
            collision.gameObject.GetComponent<PlayerMovement>().StartRotation();
            collision.gameObject.transform.rotation = checkPoint.rotation;
        }
    }
}
