using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonSound : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip btnSound;

    public void clickSound()
    {
        AudioSource.PlayOneShot(btnSound);
    }
}
