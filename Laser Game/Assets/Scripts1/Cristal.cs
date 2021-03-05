using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cristal : MonoBehaviour
{
    public GameObject angular;
    public GameObject cristal;
    public GameObject receptor;
    public GameObject FirePointCristal;
    public LineRenderer lr;

    public GameObject FirePointAngularL;
    public GameObject FirePointAngularD;

    public GameObject FirePointCristalF;
    public GameObject FirePointCristalB;

    public Collider DirCheckF;
    public Collider DirCheckB;

    public bool EncendidoB;
    public bool EncendidoF;

    public bool Encendido = false;

    void Start()
    {
        DirCheckF = gameObject.transform.GetChild(2).gameObject.GetComponent<Collider>();
        DirCheckB = gameObject.transform.GetChild(3).gameObject.GetComponent<Collider>();
        receptor = null;
        
    }

    void Update()
    {

        if (EncendidoB == true)
        {
            
            FirePointCristalF.SetActive(true);
            Fire();

        }
        else if(EncendidoF == true)
        {
            
            FirePointCristalB.SetActive(true);
            Fire();
        }
        else
        {
            FirePointCristalF.SetActive(false);
            FirePointCristalB.SetActive(false);

            if (angular != null)
            {
                cristal.GetComponent<Angular>().EncendidoD = false;
            }
            else if (receptor != null)
            {
                receptor.GetComponent<Receptor>().Encendido = false;
            }
        }
    }

    void Fire()
    {
        RaycastHit hit;

        if (Physics.Raycast(FirePointCristal.transform.position, FirePointCristal.transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "DirCheckD" || hit.collider.gameObject.tag == "DirCheckI")
            {
                Debug.Log("Entra en angular");
                if (hit.collider.gameObject.tag == "DirCheckD")
                {
                    angular = hit.collider.gameObject.transform.parent.gameObject;
                    Debug.Log(angular);
                    angular.GetComponent<Angular>().EncendidoD = true;

                    angular.GetComponent<Angular>().LastLaser(FirePointAngularL.GetComponent<LineRenderer>());

                    FirePointAngularL.GetComponent<LineRenderer>().material = lr.material;

                    receptor = null;
                    cristal = null;
                }
                else if (hit.collider.gameObject.tag == "DirCheckI")
                {
                    angular = hit.collider.gameObject.transform.parent.gameObject;
                    Debug.Log(angular);
                    angular.GetComponent<Angular>().EncendidoI = true;
                    Debug.Log("Get Laser");
                    angular.GetComponent<Angular>().LastLaser(FirePointAngularD.GetComponent<LineRenderer>());

                    FirePointAngularD.GetComponent<LineRenderer>().material = lr.material;

                    receptor = null;
                    cristal = null;
                }
            }
            else if (hit.collider.gameObject.tag == "Receptor")
            {

                receptor = hit.collider.gameObject;

                hit.collider.gameObject.GetComponent<Receptor>().Encendido = true;
                receptor.GetComponent<Receptor>().LastLaser(FirePointCristal.GetComponent<LineRenderer>());

                cristal = null;
                angular = null;
            }
            else if (hit.collider.gameObject.tag == "DirCheckF" || hit.collider.gameObject.tag == "DirCheckB")
            {
                Debug.Log("Entra en el collider");
                if (hit.collider.gameObject.tag == "DirCheckF")
                {
                    cristal = hit.collider.gameObject.transform.parent.gameObject;
                    DirCheckB.gameObject.SetActive(false);
                    cristal.GetComponent<Cristal>().EncendidoB = true;
                    cristal.GetComponent<Cristal>().LastLaser(FirePointCristalB.GetComponent<LineRenderer>());
                    
                    receptor = null;
                    angular = null;

                }
                else
                {
                    cristal = hit.collider.gameObject.transform.parent.gameObject;
                    DirCheckF.gameObject.SetActive(false);
                    cristal.GetComponent<Cristal>().EncendidoF = true;
                    cristal.GetComponent<Cristal>().LastLaser(FirePointCristalF.GetComponent<LineRenderer>());

                    receptor = null;
                    angular = null;
                }

            }

        }
        else
        {
            FirePointCristal.GetComponent<LineRenderer>().material = lr.material;

            if (cristal != null)
            {
                cristal.GetComponent<Cristal>().Encendido = false;
            }
            else if (receptor != null)
            {
                receptor.GetComponent<Receptor>().Encendido = false;
            }
            else if (angular != null)
            {
                angular.GetComponent<Angular>().EncendidoD = false;
            }
        }




    }
    public void LastLaser(LineRenderer laser)
    {
        lr = laser;
    }
}
