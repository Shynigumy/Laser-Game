using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Receptor : MonoBehaviour
{

    public bool Encendido = false;
    private LineRenderer lr;
    public string color;

    // Update is called once per frame
    void Update()
    {
        if (Encendido == true)
        {
            
            if (lr.material.name.Contains("Blue"))
            {


            }
            if (lr.material.name.Contains("Yellow"))
            {

            }

            if (lr.material.name.Contains("Orange"))
            {

            }
        }
        else
        {
            
        }
    }
    public void LastLaser(LineRenderer laser)
    {
        lr = laser;
    }

}
