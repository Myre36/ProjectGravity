using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPointScript : MonoBehaviour
{
    [SerializeField]
    private int state;

    public Transform player;

    public void UpdateBallRotation(int state)
    {
        float yRotation = player.rotation.eulerAngles.y;

        switch (state)
        {
            case 0:
                this.transform.rotation = Quaternion.Euler(0f, yRotation, 0);
                break;
            case 1:
                this.transform.rotation = Quaternion.Euler(0, yRotation, -180);
                break;
            case 2:
                this.transform.rotation = Quaternion.Euler(-90f, 0, 0);
                break;
            case 3:
                this.transform.rotation = Quaternion.Euler(90f, 0, 0);
                break;
            case 4:
                this.transform.rotation = Quaternion.Euler(0, 0, -90);
                break;
            case 5:
                this.transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            default:
                this.transform.rotation = Quaternion.Euler(0f, 0, 0);
                break;
        }
    }
}
