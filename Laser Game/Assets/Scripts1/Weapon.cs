using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject cristal;
    public GameObject FirePoint;
    public GameObject angular;
    public GameObject receptor;
    public GameObject prisma;

    public GameObject FirePointCristalF;
    public GameObject FirePointCristalB;

    void Start()
    {
        cristal = null;
        angular = null;
        receptor = null;
        prisma = null;
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    { 
        RaycastHit hit;

        if (Physics.Raycast(FirePoint.transform.position, FirePoint.transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "DirCheckD")
            {
                angular = hit.collider.gameObject.transform.parent.gameObject;
                angular.GetComponent<Angular>().EncendidoD = true;

                angular.GetComponent<Angular>().LastLaser(FirePoint.GetComponent<LineRenderer>());
                receptor = null;
                cristal = null;
                prisma = null;
            }
            else if (hit.collider.gameObject.tag == "DirCheckI")
            {
                angular = hit.collider.gameObject.transform.parent.gameObject;
                Debug.Log(angular);
                angular.GetComponent<Angular>().EncendidoI = true;

                angular.GetComponent<Angular>().LastLaser(FirePoint.GetComponent<LineRenderer>());
                receptor = null;
                cristal = null;
                prisma = null;
            }
            else if (hit.collider.gameObject.tag == "Receptor")
            {

                receptor = hit.collider.gameObject;

                hit.collider.gameObject.GetComponent<Receptor>().Encendido = true;
                if (cristal != null)
                {
                    cristal.GetComponent<Cristal>().EncendidoF = false;
                    cristal.GetComponent<Cristal>().EncendidoB = false;
                }
                angular = null;
                cristal = null;
                prisma = null;

            }
            else if (hit.collider.gameObject.tag == "DirCheckF" || hit.collider.gameObject.tag == "DirCheckB")
            {
                cristal = hit.collider.gameObject.transform.parent.gameObject;
                cristal.GetComponent<Cristal>().LastLaser(FirePoint.GetComponent<LineRenderer>());
                receptor = null;
                angular = null;
                prisma = null;

                if (hit.collider.gameObject.tag == "DirCheckF")
                {
                    Debug.Log("Entra en collider dirCheckF Weapon");
                    cristal.GetComponent<Cristal>().EncendidoB = true;
                    cristal.transform.GetChild(2).gameObject.SetActive(false);

                }
                else if (hit.collider.gameObject.tag == "DirCheckB")
                {
                    Debug.Log("Entra en collider dirCheckB Weapon");

                    cristal.GetComponent<Cristal>().EncendidoF = true;
                    cristal.transform.GetChild(1).gameObject.SetActive(false);

                }

            }
            else if (hit.collider.gameObject.tag == "Prisma IN")
            {
                prisma = hit.collider.gameObject.transform.parent.gameObject;
                prisma.GetComponent<Prisma>().Encendido = true;

                angular.GetComponent<Prisma>().LastLaser(FirePoint.GetComponent<LineRenderer>());
                receptor = null;
                cristal = null;
                angular = null;
            }

        }
        else
        {
            Debug.Log("Sale");
            if (angular != null)
            {
                angular.GetComponent<Angular>().EncendidoD = false;
                angular.GetComponent<Angular>().EncendidoI = false;
            }
            else if (receptor != null)
            {
                receptor.GetComponent<Receptor>().Encendido = false;
            }
            else if (cristal != null)
            {
                cristal.GetComponent<Cristal>().EncendidoF = false;
                cristal.GetComponent<Cristal>().EncendidoB = false;
            }
            else if (prisma != null)
            {
                prisma.GetComponent<Prisma>().Encendido = false;
            }

        }

    }

}
