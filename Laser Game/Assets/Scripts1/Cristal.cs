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

    public Collider DirCheckF;
    public Collider DirCheckB;

    public bool EncendidoB;
    public bool EncendidoF;

    public bool Encendido = false;

    void Start()
    {
        DirCheckF = gameObject.transform.GetChild(1).gameObject.GetComponent<Collider>();
        DirCheckB = gameObject.transform.GetChild(2).gameObject.GetComponent<Collider>();
        receptor = null;
        
    }

    void Update()
    {

        if (EncendidoB == true)
        {
            Debug.Log(this.transform.parent.gameObject.transform.localEulerAngles.y);
            FirePointCristal.transform.eulerAngles = new Vector3(0, 180 + this.transform.parent.gameObject.transform.localEulerAngles.y, 0);
            FirePointCristal.SetActive(true);
            Fire();

        }
        else if(EncendidoF == true)
        {
            FirePointCristal.transform.eulerAngles = new Vector3(0, this.transform.parent.gameObject.transform.localEulerAngles.y, 0);
            FirePointCristal.SetActive(true);
            Fire();
        }
        else
        {
            FirePointCristal.transform.rotation = new Quaternion(0, FirePointCristal.transform.rotation.y, FirePointCristal.transform.rotation.z, 0);
            FirePointCristal.SetActive(false);
            DirCheckB.gameObject.SetActive(true);
            DirCheckF.gameObject.SetActive(true);
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


                    receptor = null;
                    cristal = null;
                }
                else if (hit.collider.gameObject.tag == "DirCheckI")
                {
                    angular = hit.collider.gameObject.transform.parent.gameObject;
                    Debug.Log(angular);
                    angular.GetComponent<Angular>().EncendidoI = true;
                    Debug.Log("Get Laser");

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
                if (hit.collider.gameObject.tag == "DirCheckF")
                {
                    Debug.Log("Entra en collider dirCheckF");
                    cristal = hit.collider.gameObject.transform.parent.gameObject;
                    DirCheckB.gameObject.SetActive(false);
                    cristal.GetComponent<Cristal>().EncendidoB = true;
                    cristal.GetComponent<Cristal>().LastLaser(FirePointCristal.GetComponent<LineRenderer>());
                    
                    receptor = null;
                    angular = null;

                }
                else if (hit.collider.gameObject.tag == "DirCheckB")
                {
                    Debug.Log("Entra en collider dirCheckB Cristal");
                    cristal = hit.collider.gameObject.transform.parent.gameObject;
                    DirCheckF.gameObject.SetActive(false);
                    cristal.GetComponent<Cristal>().EncendidoF = true;
                    cristal.GetComponent<Cristal>().LastLaser(FirePointCristal.GetComponent<LineRenderer>());

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
