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
    public GameObject prisma;

    public Collider DirCheckF;
    public Collider DirCheckB;

    public bool EncendidoB;
    public bool EncendidoF;

    void Start()
    {
        DirCheckF = gameObject.transform.GetChild(1).gameObject.GetComponent<Collider>();
        DirCheckB = gameObject.transform.GetChild(2).gameObject.GetComponent<Collider>();
        cristal = null;
        angular = null;
        receptor = null;
        prisma = null;
    }

    void Update()
    {

        if (EncendidoB == true)
        {
            FirePointCristal.transform.eulerAngles = new Vector3(0, 180 + this.transform.parent.gameObject.transform.localEulerAngles.y, 0);
            FirePointCristal.SetActive(true);
            DirCheckB.gameObject.SetActive(false);
            Fire();
            
        }
        else if(EncendidoF == true)
        {
            FirePointCristal.transform.eulerAngles = new Vector3(0, this.transform.parent.gameObject.transform.localEulerAngles.y, 0);
            FirePointCristal.SetActive(true);
            DirCheckF.gameObject.SetActive(false);
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
                angular.GetComponent<Angular>().EncendidoD = false;
                angular.GetComponent<Angular>().EncendidoI = false;
            }
            else if (receptor != null)
            {
                receptor.GetComponent<Receptor>().Encendido = false;
            }
            else if (cristal != null)
            {
                cristal.GetComponent<Cristal>().EncendidoB = false;
                cristal.GetComponent<Cristal>().EncendidoF = false;
            }
            else if (prisma != null)
            {
                prisma.GetComponent<Prisma>().Encendido = false;
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
                if (hit.collider.gameObject.tag == "DirCheckD")
                {
                    angular = hit.collider.gameObject.transform.parent.gameObject;
                    angular.GetComponent<Angular>().EncendidoD = true;

                    angular.GetComponent<Angular>().LastLaser(FirePointCristal.GetComponent<LineRenderer>());
                    DesactivarReceptorPrisma();
                    DesactivarCristalPrisma();
                    receptor = null;
                    cristal = null;
                }
                else if (hit.collider.gameObject.tag == "DirCheckI")
                {
                    angular = hit.collider.gameObject.transform.parent.gameObject;
                    angular.GetComponent<Angular>().EncendidoI = true;

                    angular.GetComponent<Angular>().LastLaser(FirePointCristal.GetComponent<LineRenderer>());
                    DesactivarReceptorPrisma();
                    DesactivarCristalPrisma();
                    receptor = null;
                    cristal = null;
                }
            }
            else if (hit.collider.gameObject.tag == "Receptor")
            {

                receptor = hit.collider.gameObject;

                hit.collider.gameObject.GetComponent<Receptor>().Encendido = true;
                receptor.GetComponent<Receptor>().LastLaser(FirePointCristal.GetComponent<LineRenderer>());
                DesactivarCristalPrisma();
                DesactivarAngularPrisma();

                cristal = null;
                angular = null;
            }
            else if (hit.collider.gameObject.tag == "DirCheckF" || hit.collider.gameObject.tag == "DirCheckB")
            {
                if (hit.collider.gameObject.tag == "DirCheckF")
                {
                    Debug.Log("Entra en collider dirCheckF");
                    cristal = hit.collider.gameObject.transform.parent.gameObject;
                    cristal.GetComponent<Cristal>().EncendidoB = true;

                    DesactivarReceptorPrisma();
                    DesactivarAngularPrisma();
                    receptor = null;
                    angular = null;

                }
                else if (hit.collider.gameObject.tag == "DirCheckB")
                {
                    Debug.Log("Entra en collider dirCheckB Cristal");
                    cristal = hit.collider.gameObject.transform.parent.gameObject;
                    cristal.GetComponent<Cristal>().EncendidoF = true;

                    DesactivarReceptorPrisma();
                    DesactivarAngularPrisma();
                    receptor = null;
                    angular = null;
                }
            }
            else if (hit.collider.gameObject.tag == "Prisma IN")
            {
                Debug.Log(prisma);
                prisma = hit.collider.gameObject;
                Debug.Log(prisma);
                prisma.GetComponent<Prisma>().Encendido = true;

                prisma.GetComponent<Prisma>().LastLaser(FirePointCristal.GetComponent<LineRenderer>());
                receptor = null;
                cristal = null;
                angular = null;
                DesactivarAngularCristal();
                DesactivarAngularReceptor();
            }
            else if(hit.collider.gameObject.tag == "Wall")
            {
                Desactivar();
                FirePointCristal.GetComponent<LineRenderer>().material = lr.material;
            }
        }
        else
        {

            Desactivar();
            FirePointCristal.GetComponent<LineRenderer>().material = lr.material;
        }

    }
    public void LastLaser(LineRenderer laser)
    {
        lr = laser;
    }
    public void DesactivarReceptorCristal()
    {

        if (receptor != null)
        {
            receptor.GetComponent<Receptor>().Encendido = false;
        }
        if (cristal != null)
        {
            Debug.Log("False");
            cristal.GetComponent<Cristal>().EncendidoF = false;
            cristal.GetComponent<Cristal>().EncendidoB = false;
        }
    }
    public void DesactivarAngularPrisma()
    {

        if (angular != null)
        {
            angular.GetComponent<Angular>().EncendidoD = false;
            angular.GetComponent<Angular>().EncendidoI = false;
        }
        if (prisma != null)
        {
            prisma.GetComponent<Prisma>().Encendido = false;
        }

    }
    public void DesactivarReceptorPrisma()
    {

        if (receptor != null)
        {
            receptor.GetComponent<Receptor>().Encendido = false;
        }
        if (prisma != null)
        {
            prisma.GetComponent<Prisma>().Encendido = false;
        }

    }
    public void DesactivarCristalPrisma()
    {
        if (prisma != null)
        {
            prisma.GetComponent<Prisma>().Encendido = false;
        }

        if (cristal != null)
        {
            Debug.Log("False");
            cristal.GetComponent<Cristal>().EncendidoF = false;
            cristal.GetComponent<Cristal>().EncendidoB = false;
        }
    }
    public void DesactivarAngularCristal()
    {
        if (angular != null)
        {
            angular.GetComponent<Angular>().EncendidoD = false;
            angular.GetComponent<Angular>().EncendidoI = false;
        }
        if (cristal != null)
        {
            Debug.Log("False");
            cristal.GetComponent<Cristal>().EncendidoF = false;
            cristal.GetComponent<Cristal>().EncendidoB = false;
        }
    }
    public void DesactivarAngularReceptor()
    {
        if (angular != null)
        {
            angular.GetComponent<Angular>().EncendidoD = false;
            angular.GetComponent<Angular>().EncendidoI = false;
        }
        if (receptor != null)
        {
            receptor.GetComponent<Receptor>().Encendido = false;
        }
    }
    public void Desactivar()
    {
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
            Debug.Log("False");
            cristal.GetComponent<Cristal>().EncendidoF = false;
            cristal.GetComponent<Cristal>().EncendidoB = false;
        }
        else if (prisma != null)
        {
            prisma.GetComponent<Prisma>().Encendido = false;
        }
    }
}
