using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int bulletType = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Interactable"))
        {
            other.GetComponent<GravityComponent>().gravityStatus = bulletType;
        }

        Destroy(gameObject);
    }
}
