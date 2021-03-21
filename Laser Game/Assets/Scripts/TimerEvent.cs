using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerEvent : MonoBehaviour
{
    public float velocidadApagado = 0.5f;
    public float TiempoExplocion = 19.5f;
    public float TiempoAlerta = 22f;
    public float TiempoFinal = 30f;
    public float tiempo = 0f;
    public float tiempoTransicion = 0f;
    public float tiempoTransicionFinal = 3f;
    private bool continuar = false;

    public GameObject temblor;
    public GameObject rotacion;
    public GameObject LuzRoja1;
    public GameObject LuzRoja2;
    public GameObject Escombros;
    public GameObject SonidoExplosion;
    public GameObject SonidoAlarma;
    public GameObject NaveAzul;
    public GameObject NaveRojo;
    public GameObject ControlesAzul;
    public GameObject ControlesRojo;
    public GameObject TextoAlerta;

    public GameObject Camara;

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;

        if (tiempo >= TiempoExplocion && tiempo <= TiempoAlerta)
        {
            temblor.GetComponent<VibrarCamara>().enabled = true;
            temblor.GetComponent<VibrarCamara>().power = 0.015f;
            rotacion.GetComponent<RotacionNave>().enabled = true;
            SonidoExplosion.GetComponent<AudioSource>().enabled = true;
            NaveAzul.SetActive(false);
            NaveRojo.SetActive(true);
            ControlesAzul.SetActive(false);
            ControlesRojo.SetActive(true);

        } 
        
        else if (tiempo >= TiempoAlerta && continuar != true)
        {
            temblor.GetComponent<VibrarCamara>().power = 0.005f;
            LuzRoja1.GetComponent<LucesRojasParpadeo>().enabled = true;
            LuzRoja2.GetComponent<LucesRojasParpadeo>().enabled = true;
            SonidoAlarma.GetComponent<AudioSource>().enabled = true;
            Escombros.SetActive(true);
        }
        
        if (tiempo >= TiempoFinal)
        {
            TextoAlerta.SetActive(true);
        }

          if (tiempo >= TiempoFinal && Input.GetKeyDown(KeyCode.Space))
        {
            continuar = true;
        }

        if (continuar == true)
        {
            LuzRoja1.GetComponent<LucesRojasParpadeo>().enabled = false;
            LuzRoja1.GetComponent<Light>().intensity -= velocidadApagado;
            LuzRoja2.GetComponent<LucesRojasParpadeo>().enabled = false;
            LuzRoja2.GetComponent<Light>().intensity -= velocidadApagado;
            Camara.GetComponent<Transform>().Rotate(new Vector3(0f, 30f, 0f) * Time.deltaTime);
            tiempoTransicion += Time.deltaTime;
        }

        if ( tiempoTransicion >= tiempoTransicionFinal)
        {
            SceneManager.LoadScene(2);
        }
    }
}
