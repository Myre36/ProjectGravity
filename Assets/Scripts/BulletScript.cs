using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int bulletType = 0;

    //public GameObject player;

    private void Start()
    {
        //player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Interactable"))
        {
            other.GetComponent<GravityComponent>().gravityStatus = bulletType;

            /*if (other.gameObject.GetComponent<GravityComponent>().gravityStatus == bulletType)
            {
                other.gameObject.GetComponent<GravityComponent>().gravityStatus = player.GetComponent<GravityComponent>().gravityStatus;
            }
            else
            {
                other.GetComponent<GravityComponent>().gravityStatus = bulletType;
            }*/
        }

        Destroy(gameObject);
    }
}
