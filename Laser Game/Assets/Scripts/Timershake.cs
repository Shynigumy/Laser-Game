using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timershake : MonoBehaviour
{

    public float TiempoExplocion = 5f;
    public float tiempo = 0f;

    public GameObject temblor;
    public GameObject SonidoExplosion;

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;

        if (tiempo >= TiempoExplocion)
        {
            temblor.GetComponent<VibrarCamara>().shouldShake = true;
            SonidoExplosion.GetComponent<AudioSource>().Play(1);
            tiempo = 0;
        }

        
    }
}