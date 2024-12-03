using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVoice : MonoBehaviour
{
    public AudioSource startingVoice;

    public GameObject door;

    public Transform endPoint;

    public bool opened = false;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OpenDoorAfterVoice());
    }

    private void FixedUpdate()
    {
        if (opened == true)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, endPoint.position, speed);
        }
    }

    IEnumerator OpenDoorAfterVoice()
    {
        yield return new WaitForSeconds(3);
        startingVoice.Play();
        yield return new WaitForSeconds(11);
        opened = true;
    }
}
