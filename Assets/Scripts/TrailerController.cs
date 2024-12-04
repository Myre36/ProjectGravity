using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerController : MonoBehaviour
{
    public GameObject[] gameObj;
    private bool clicked = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!clicked)
            {
                foreach (GameObject f in gameObj)
                {
                    f.SetActive(false);
                }
            }
            else
            {
                foreach (GameObject v in gameObj)
                {
                    v.SetActive(true);
                }
            }
        }
    }
}
