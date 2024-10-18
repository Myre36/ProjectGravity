using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityComponent : MonoBehaviour
{
    public int gravityStatus = 0;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && gravityStatus != 0)
        {
            gravityStatus = 0;

            SwitchGravity();
        }
        if (Input.GetKeyDown(KeyCode.E) && gravityStatus != 1)
        {
            gravityStatus = 1;

            SwitchGravity();
        }
        if (Input.GetKeyDown(KeyCode.T) && gravityStatus != 2)
        {
            gravityStatus = 2;

            SwitchGravity();

        }
        if (Input.GetKeyDown(KeyCode.Y) && gravityStatus != 3)
        {
            gravityStatus = 3;

            SwitchGravity();

        }
        if (Input.GetKeyDown(KeyCode.U) && gravityStatus != 4)
        {
            gravityStatus = 4;

            SwitchGravity();
        }
        if (Input.GetKeyDown(KeyCode.I) && gravityStatus != 5)
        {
            gravityStatus = 5;

            SwitchGravity();
        }
    }*/

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (gravityStatus)
        {
            case 0:
                rb.AddForce(new Vector3(0f, -9.81f, 0f));
                break;
            case 1:
                rb.AddForce(new Vector3(0f, 9.81f, 0f));
                break;
            case 2:
                rb.AddForce(new Vector3(0f, 0f, 9.81f));
                break;
            case 3:
                rb.AddForce(new Vector3(0f, 0f, -9.81f));
                break;
            case 4:
                rb.AddForce(new Vector3(-9.81f, 0f, 0f));
                break;
            case 5:
                rb.AddForce(new Vector3(9.81f, 0f, 0f));
                break;
            default:
                break;
        }
    }

    void RotatePlayer()
    {
        float yRotation;
        switch (gravityStatus)
        {
            case 0:
                yRotation = transform.rotation.y;

                transform.rotation = Quaternion.Euler(0, yRotation, 0f);
                break;
            case 1:
                yRotation = transform.rotation.y;

                transform.rotation = Quaternion.Euler(-180f, yRotation, 0f);
                break;
            case 2:
                yRotation = transform.rotation.y;

                transform.rotation = Quaternion.Euler(-90, yRotation, 0f);
                break;
            case 3:
                yRotation = transform.rotation.y;

                transform.rotation = Quaternion.Euler(90, yRotation, 0f);
                break;
            case 4:
                yRotation = transform.rotation.y;

                transform.rotation = Quaternion.Euler(0f, yRotation, -90f);
                break;
            case 5:
                yRotation = transform.rotation.y;

                transform.rotation = Quaternion.Euler(0f, yRotation, 90f);
                break;
            default:
                break;
        }
    }
}
