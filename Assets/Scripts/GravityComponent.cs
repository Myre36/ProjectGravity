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
}
