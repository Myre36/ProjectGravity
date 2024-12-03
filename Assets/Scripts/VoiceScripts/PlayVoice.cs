using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVoice : MonoBehaviour
{
    public AudioSource voiceClip;

    public GameObject previousVoiceClip;

    private bool entered;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(entered == false)
            {
                Destroy(previousVoiceClip);
                voiceClip.Play();
                entered = true;
            }
            
        }
    }
}
