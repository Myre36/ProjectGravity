using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndVoice : MonoBehaviour
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
                StartCoroutine(EndGame());
            }
        }
    }

    IEnumerator EndGame()
    {
        Destroy(previousVoiceClip);
        voiceClip.Play();
        entered = true;
        yield return new WaitForSeconds(13);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Menu");
    }
}
