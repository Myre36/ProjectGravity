using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityButtonsScript : MonoBehaviour
{
    public int rotationSetting;

    public GameObject player;

    public GameObject highlight;

    private void OnMouseOver()
    {
        highlight.SetActive(true);
        player.GetComponent<PlayerMovement>().gravityNumber = rotationSetting;
        player.GetComponent<LazerScript>().gravityType = rotationSetting;
        Debug.Log("Testing: This is with setting " + rotationSetting);
    }

    
    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }

    
}
