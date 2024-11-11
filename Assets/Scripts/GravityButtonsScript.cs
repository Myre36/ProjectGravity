using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityButtonsScript : MonoBehaviour
{
    public int rotationSetting;

    public GameObject player;

    public void ChangeGravityUp()
    {
        switch(player.GetComponent<PlayerMovement>().gravityNumber)
        {
            case 0:
                rotationSetting = 1; 
                break;
            case 1:
                rotationSetting = 0;
                break;
            case 2:
                rotationSetting = 3;
                break;
            case 3:
                rotationSetting = 2;
                break;
        }
        player.GetComponent<PlayerMovement>().gravityNumber = rotationSetting;
        player.GetComponent<LazerScript>().gravityType = rotationSetting;
    }
    public void ChangeGravityForward()
    {
        player.GetComponent<PlayerMovement>().gravityNumber = rotationSetting;
        player.GetComponent<LazerScript>().gravityType = rotationSetting;
    }
    public void ChangeGravityBackwards()
    {
        player.GetComponent<PlayerMovement>().gravityNumber = rotationSetting;
        player.GetComponent<LazerScript>().gravityType = rotationSetting;
    }
    public void ChangeGravityLeft()
    {
        player.GetComponent<PlayerMovement>().gravityNumber = rotationSetting;
        player.GetComponent<LazerScript>().gravityType = rotationSetting;
    }
    public void ChangeGravityRight()
    {
        player.GetComponent<PlayerMovement>().gravityNumber = rotationSetting;
        player.GetComponent<LazerScript>().gravityType = rotationSetting;
    }
}
