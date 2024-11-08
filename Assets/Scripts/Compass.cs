using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField]
    TMP_Text primDirectionText, primNeighbourDirectionText, secNeighbourDirectionText;

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
        string leftDirection = "";
        string rightDirection = "";

        if (pitch <= -45f && lastVerticalDirection != "Up")
        {
            primaryDirection = "Up";
            lastVerticalDirection = "Up";
            leftDirection = "West";
            rightDirection = "East";
        }
        else if (pitch >= 45f && lastVerticalDirection != "Down")
        {
            primaryDirection = "Down";
            lastVerticalDirection = "Down";
            leftDirection = "East";
            rightDirection = "West";
        }
        else
        {
            return;
        }

        primDirectionText.text = primaryDirection;
        primNeighbourDirectionText.text = leftDirection;
        secNeighbourDirectionText.text = rightDirection;
    }

    void SetHorizontalDirection(float yaw, float pitch)
    {
        if (Mathf.Abs(pitch) > 45f)
            return;

        string primaryDirection = "";
        string leftDirection = "";
        string rightDirection = "";

        yaw = yaw % 360;

        int directionZone = Mathf.FloorToInt((yaw + 22.5f) / 45f) % 8;

        switch (directionZone)
        {
            case 0:
                primaryDirection = "N";
                leftDirection = "NW";
                rightDirection = "NE";
                break;
            case 1:
                primaryDirection = "NE";
                leftDirection = "N";
                rightDirection = "E";
                break;
            case 2:
                primaryDirection = "E";
                leftDirection = "NE";
                rightDirection = "SE";
                break;
            case 3:
                primaryDirection = "SE";
                leftDirection = "E";
                rightDirection = "S";
                break;
            case 4:
                primaryDirection = "S";
                leftDirection = "SE";
                rightDirection = "SW";
                break;
            case 5:
                primaryDirection = "SW";
                leftDirection = "S";
                rightDirection = "W";
                break;
            case 6:
                primaryDirection = "W";
                leftDirection = "SW";
                rightDirection = "NW";
                break;
            case 7:
                primaryDirection = "NW";
                leftDirection = "W";
                rightDirection = "N";
                break;
            default:
                break;
        }

        primDirectionText.text = primaryDirection;
        primNeighbourDirectionText.text = leftDirection;
        secNeighbourDirectionText.text = rightDirection;
    }
}