using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioAudio : MonoBehaviour
{
    public GameObject audioOut;
    public float volum = 0.1f;

    void Update()
    {
        if(audioOut.GetComponent<AudioSource>().volume <= 1)
        {
            audioOut.GetComponent<AudioSource>().volume += volum * Time.deltaTime ;
        }
    }
}
