using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateDoor : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    public float speed;

    private bool open;

    public int assignedNumber;

    public int buttonsPressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == endPoint.position)
        {
            Destroy(gameObject);
        }

        if(buttonsPressed >= assignedNumber)
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
        if(open == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, speed);
        }
    }
}
