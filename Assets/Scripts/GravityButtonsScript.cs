using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityButtonsScript : MonoBehaviour
{
    public int rotationSetting;

    public GameObject player;

    private int lastGravitySetting;

    public void ChangeGravityUp()
    {
        /*lastGravitySetting = rotationSetting;
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
            case 4:
                rotationSetting = 5;
                break;
            case 5:
                rotationSetting = 4;
                break;
        }*/
        player.GetComponent<PlayerMovement>().gravityNumber = rotationSetting;
        player.GetComponent<LazerScript>().gravityType = rotationSetting;
    }
    public void ChangeGravityForward()
    {
        //lastGravitySetting = rotationSetting;
        player.GetComponent<PlayerMovement>().gravityNumber = rotationSetting;
        player.GetComponent<LazerScript>().gravityType = rotationSetting;
    }
    public void ChangeGravityBackwards()
    {
        //lastGravitySetting = rotationSetting;
        player.GetComponent<PlayerMovement>().gravityNumber = rotationSetting;
        player.GetComponent<LazerScript>().gravityType = rotationSetting;
    }
    public void ChangeGravityLeft()
    {
        //lastGravitySetting = rotationSetting;
        player.GetComponent<PlayerMovement>().gravityNumber = rotationSetting;
        player.GetComponent<LazerScript>().gravityType = rotationSetting;
    }
    public void ChangeGravityRight()
    {
        //lastGravitySetting = rotationSetting;
        player.GetComponent<PlayerMovement>().gravityNumber = rotationSetting;
        player.GetComponent<LazerScript>().gravityType = rotationSetting;
    }

    public void ResetButton()
    {
        /*rotationSetting = lastGravitySetting;
        player.GetComponent<PlayerMovement>().gravityNumber = rotationSetting;
        player.GetComponent<LazerScript>().gravityType = rotationSetting;*/
    }
}
