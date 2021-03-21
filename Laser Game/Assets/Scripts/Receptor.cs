using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Receptor : MonoBehaviour
{

    public bool Encendido = false;
    private LineRenderer lr;
    public string WinColor;
    public string RecievedColor;
    public GameObject WinCanvas;


    // Update is called once per frame
    void Update()
    {
        if (Encendido == true)
        {
            
            if (lr.material.name.Contains("Blue"))
            {
                RecievedColor = ("Blue");
                if(RecievedColor == "Blue" && WinColor == "Blue")
                {
                    WinCanvas.gameObject.SetActive(true);
                }

            }
            if (lr.material.name.Contains("Yellow"))
            {
                RecievedColor = ("Yellow");
                if (RecievedColor == "Yellow" && WinColor == "Yellow")
                {
                    WinCanvas.gameObject.SetActive(true);
                }
            }
            if (lr.material.name.Contains("Purple"))
            {
                RecievedColor = ("Purple");
                if (RecievedColor == "Purple" && WinColor == "Purple")
                {
                    WinCanvas.gameObject.SetActive(true);
                }
            }
            if (lr.material.name.Contains("Red"))
            {
                RecievedColor = ("Red");
                if (RecievedColor == "Red" && WinColor == "Red")
                {
                    WinCanvas.gameObject.SetActive(true);
                }
            }

            if (lr.material.name.Contains("Green"))
            {
                RecievedColor = ("Green");
                if (RecievedColor == "Green" && WinColor == "Green")
                {
                    WinCanvas.gameObject.SetActive(true);
                }
            }
            if (lr.material.name.Contains("Orange"))
            {
                RecievedColor = ("Orange");
                if (RecievedColor == "Orange" && WinColor == "Orange")
                {
                    WinCanvas.gameObject.SetActive(true);
                }
            }
        }

    }
    public void LastLaser(LineRenderer laser)
    {
        lr = laser;
    }

}
