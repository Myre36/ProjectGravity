using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLazerScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<GravityComponent>().gravityStatus = 1;

            other.transform.localRotation = Quaternion.Euler(0f, other.transform.rotation.y, -180f);
        }
    }
}
