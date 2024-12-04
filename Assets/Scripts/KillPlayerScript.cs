using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillPlayerScript : MonoBehaviour
{
    public Transform checkPoint;
    public TMP_Text gravityText;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = checkPoint.position;
            collision.gameObject.GetComponent<GravityComponent>().gravityStatus = 0;
            collision.gameObject.transform.rotation = checkPoint.rotation;
        }
    }
}
