using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLazerScript : MonoBehaviour
{

    public int assignedNumber = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<GravityComponent>().gravityStatus = assignedNumber;

            if(assignedNumber == 0 )
            {
                other.transform.localRotation = Quaternion.Euler(0f, other.transform.rotation.y, 0f);
            }
            else if(assignedNumber == 1 )
            {
                other.transform.localRotation = Quaternion.Euler(0f, other.transform.rotation.y, -180f);
            }
            else if (assignedNumber == 2)
            {
                other.transform.localRotation = Quaternion.Euler(-90, other.transform.rotation.y, 0);
            }
            else if (assignedNumber == 3)
            {
                other.transform.localRotation = Quaternion.Euler(90, other.transform.rotation.y, 0);
            }
            else if (assignedNumber == 4)
            {
                other.transform.localRotation = Quaternion.Euler(0, other.transform.rotation.y, -90);
            }
            else if (assignedNumber == 5)
            {
                other.transform.localRotation = Quaternion.Euler(0, other.transform.rotation.y, 90);
            }
        }
    }
}
