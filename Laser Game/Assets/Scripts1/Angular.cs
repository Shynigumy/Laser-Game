using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angular : MonoBehaviour
{
    public GameObject cristal;
    public GameObject angular;
    public GameObject receptor;
    public GameObject FirePointAngularL;
    public GameObject FirePointAngularD;
    public LineRenderer lr;

    public Collider DirCheckD;
    public Collider DirCheckI;
    public bool DirCheck;

    public GameObject FirePointCristalB;
    public GameObject FirePointCristalF;


    public bool EncendidoD = false;
    public bool EncendidoI = false;
    void Start()
    {
        DirCheckD = gameObject.transform.GetChild(2).GetComponent<Collider>();
        DirCheckI = gameObject.transform.GetChild(3).GetComponent<Collider>();
        receptor = null;
        cristal = null;
    }

    void Update()
    {

        if (EncendidoD == true)
        {
            Debug.Log("EncendidoD Working");
            DirCheckI.gameObject.SetActive(false);
            FirePointAngularL.SetActive(true);
            Fire();

        }
        else if (EncendidoI == true)
        {
            DirCheckD.gameObject.SetActive(false);
            FirePointAngularD.SetActive(true);
            Fire();


        }
        else
        {
            FirePointAngularL.SetActive(false);
            FirePointAngularD.SetActive(false);

            if (angular != null)
            {
                angular.GetComponent<Angular>().EncendidoD = false;
            }
            else if (receptor != null)
            {
                receptor.GetComponent<Receptor>().Encendido = false;
            }
            else if (cristal != null)
            {
                cristal.GetComponent<Cristal>().Encendido = false;
            }
        }
    }

    void Fire()
    {
        RaycastHit hit;

        if (Physics.Raycast(FirePointAngularL.transform.position, FirePointAngularL.transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "DirCheckD" || hit.collider.gameObject.tag == "DirCheckI")
            {
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
                else if (hit.collider.gameObject.tag == "Receptor")
                {

                    receptor = hit.collider.gameObject;

                    hit.collider.gameObject.GetComponent<Receptor>().Encendido = true;
                    angular = null;
                    cristal = null;
                    receptor.GetComponent<Receptor>().LastLaser(FirePointAngularL.GetComponent<LineRenderer>());

                    FirePointAngularL.GetComponent<LineRenderer>().material = lr.material;

                }
                else if (hit.collider.gameObject.tag == "DirCheckF" || hit.collider.gameObject.tag == "DirCheckB")
                {

                    if (hit.collider.gameObject.tag == "DirCheckF")
                    {
                        cristal = hit.collider.gameObject.transform.parent.gameObject;

                        cristal.GetComponent<Cristal>().EncendidoB = true;
                        cristal.GetComponent<Cristal>().LastLaser(FirePointCristalB.GetComponent<LineRenderer>());


                        receptor = null;
                        angular = null;
                    }
                    else if (hit.collider.gameObject.tag == "DirCheckB")
                    {
                        cristal = hit.collider.gameObject.transform.parent.gameObject;

                        cristal.GetComponent<Cristal>().EncendidoF = true;
                        cristal.GetComponent<Cristal>().LastLaser(FirePointCristalF.GetComponent<LineRenderer>());

                        receptor = null;
                        angular = null;
                    }

                }


            }
            else
            {
                FirePointAngularL.GetComponent<LineRenderer>().material = lr.material;
                FirePointAngularD.GetComponent<LineRenderer>().material = lr.material;

                if (angular != null)
                {
                    angular.GetComponent<Angular>().EncendidoD = false;
                }
                else if (receptor != null)
                {
                    receptor.GetComponent<Receptor>().Encendido = false;
                }
                else if (cristal != null)
                {
                    cristal.GetComponent<Cristal>().Encendido = false;
                }
            }




        }

    }
    public void LastLaser(LineRenderer laser)
    {
        
        lr = laser;
    }
}