using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField]
    TMP_Text primDirectionText;

    [SerializeField]
    Transform playerLook;

    [SerializeField]
    float primFontSize;

    float secFontSize;

    [SerializeField]
    float secFontOpacity;

    private string lastVerticalDirection = "";

    void Start()
    {
        secFontSize = primFontSize * 0.8f;
    }

    void Update()
    {
        Vector3 PlayerEulerAngles = playerLook.eulerAngles;

        float yaw = PlayerEulerAngles.y;
        float pitch = PlayerEulerAngles.x;

        if (pitch > 180f)
        {
            pitch -= 360f;
        }

        SetVerticalDirection(pitch);

        SetHorizontalDirection(yaw, pitch);

        Debug.Log($"Yaw: {yaw}, Pitch: {pitch}");
    }

    void SetVerticalDirection(float pitch)
    {
        string primaryDirection = "";
        

        if (pitch <= -45f && lastVerticalDirection != "Up")
        {
            primaryDirection = "Up";
            lastVerticalDirection = "Up";
            
        }
        else if (pitch >= 45f && lastVerticalDirection != "Down")
        {
            primaryDirection = "Down";
            lastVerticalDirection = "Down";
            
        }
        else
        {
            return;
        }

        primDirectionText.text = primaryDirection;
        
    }

    void SetHorizontalDirection(float yaw, float pitch)
    {
        if (Mathf.Abs(pitch) > 45f)
            return;

        string primaryDirection = "";
        

        yaw = yaw % 360;

        int directionZone = Mathf.FloorToInt((yaw + 22.5f) / 45f) % 8;

        switch (directionZone)
        {
            case 0:
                primaryDirection = "North";
                
                break;
            case 1:
                primaryDirection = "NE";
                
                break;
            case 2:
                primaryDirection = "East";
                
                break;
            case 3:
                primaryDirection = "SE";
                
                break;
            case 4:
                primaryDirection = "South";
                
                break;
            case 5:
                primaryDirection = "SW";
                
                break;
            case 6:
                primaryDirection = "West";
                
                break;
            case 7:
                primaryDirection = "NW";
                
                break;
            default:
                break;
        }

        primDirectionText.text = primaryDirection;
        
    }
}