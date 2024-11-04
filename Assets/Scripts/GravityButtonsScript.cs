using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityButtonsScript : MonoBehaviour
{
    public int rotationSetting;

    public GameObject player;

    public void ChangeGravity()
    {
        player.GetComponent<PlayerMovement>().gravityNumber = rotationSetting;
        player.GetComponent<LazerScript>().gravityType = rotationSetting;
    }
}
