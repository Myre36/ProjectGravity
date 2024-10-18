using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int bulletType = 0;
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
