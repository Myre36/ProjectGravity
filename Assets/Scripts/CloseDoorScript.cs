using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorScript : MonoBehaviour
{
    public GameObject door;

    public Transform startPoint;
    public Transform endPoint;

    public float speed;

    public bool closed = false;

    public GameObject closeDoorSound;

    private void Start()
    {
        closeDoorSound = GameObject.Find("ClosingDoorSound");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(closed == false)
            {
                closeDoorSound.GetComponent<AudioSource>().Play();
            }
            closed = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(closed == true)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, endPoint.position, speed);
        }
        else
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, startPoint.position, speed);
        }
    }
}
