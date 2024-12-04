using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    public float speed;

    private bool open;

    public int assignedNumber;

    public int buttonsPressed;

    // Update is called once per frame
    void Update()
    {
        if (buttonsPressed >= assignedNumber)
        {
            open = true;
        }
        else
        {
            open = false;
        }
    }

    private void FixedUpdate()
    {
        if (open == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, speed);
        }
    }
}