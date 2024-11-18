using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityButtonsScript : MonoBehaviour
{
    public int rotationSetting;

    public GameObject player;

    public GameObject highlight;

    public Material originalMaterial;
    public Material overrideMaterial;

    public GameObject arrow;
    public GameObject arrowHead;

    private void OnMouseOver()
    {
        highlight.SetActive(true);
        arrow.GetComponent<Renderer>().material = overrideMaterial;
        arrowHead.GetComponent<Renderer>().material = overrideMaterial;
        player.GetComponent<PlayerMovement>().gravityNumber = rotationSetting;
        player.GetComponent<LazerScript>().gravityType = rotationSetting;
        Debug.Log("Testing: This is with setting " + rotationSetting);
    }
    
    private void OnMouseExit()
    {
        highlight.SetActive(false);
        arrow.GetComponent<Renderer>().material = originalMaterial;
        arrowHead.GetComponent<Renderer>().material = originalMaterial;
    }

    
}
