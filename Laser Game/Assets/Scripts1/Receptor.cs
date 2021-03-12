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
            Debug.Log(lr.material.ToString());

            if (lr.material.name == color)
            {
                Debug.Log("Win");
                
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
