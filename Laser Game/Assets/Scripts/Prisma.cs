using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prisma : MonoBehaviour
{

    public GameObject prisma;
    public GameObject cristal;
    public GameObject angular;
    public GameObject receptor;
    public GameObject FirePointPrismaR;
    public GameObject FirePointPrismaL;

    public LineRenderer lr;
    public Material blueMat;
    public Material redMat;
    public Material yellowMat;

    public Collider PrismaColliderR;
    public Collider PrismaColliderL;

    public string Lasercolor;

    public bool Encendido;

    // Start is called before the first frame update
    void Start()
    {
        cristal = null;
        angular = null;
        receptor = null;
        prisma = null;

        Encendido = false;
        PrismaColliderR.gameObject.SetActive(true);
        PrismaColliderL.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Encendido == true)
        {
            PrismaColliderR.gameObject.SetActive(false);
            PrismaColliderL.gameObject.SetActive(false);
            if (lr.material.name.Contains("Green"))
            {
                FirePointPrismaR.GetComponent<LineRenderer>().material = blueMat;
                FirePointPrismaL.GetComponent<LineRenderer>().material = yellowMat;

                FirePointPrismaR.SetActive(true);
                FirePointPrismaL.SetActive(true);
                Fire();
                
            }
            if (lr.material.name.Contains("Purple"))
            {
                FirePointPrismaR.GetComponent<LineRenderer>().material = blueMat;
                FirePointPrismaL.GetComponent<LineRenderer>().material = redMat;

                FirePointPrismaR.SetActive(true);
                FirePointPrismaL.SetActive(true);
                Fire();
            }
            if (lr.material.name.Contains("Orange"))
            {
                FirePointPrismaR.GetComponent<LineRenderer>().material = redMat;
                FirePointPrismaL.GetComponent<LineRenderer>().material = yellowMat;

                FirePointPrismaR.SetActive(true);
                FirePointPrismaL.SetActive(true);
                Fire();
            }

        }
        else
        {
            FirePointPrismaR.SetActive(false);
            FirePointPrismaL.SetActive(false);

            PrismaColliderR.gameObject.SetActive(true);
            PrismaColliderL.gameObject.SetActive(true);

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
    void Fire()
    {
        RaycastHit hit;

        if (Physics.Raycast(FirePointPrismaR.transform.position, FirePointPrismaR.transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "DirCheckD" || hit.collider.gameObject.tag == "DirCheckI")
            {
                if (hit.collider.gameObject.tag == "DirCheckD")
                {
                    angular = hit.collider.gameObject.transform.parent.gameObject;
                    angular.GetComponent<Angular>().EncendidoD = true;

                    angular.GetComponent<Angular>().LastLaser(FirePointPrismaR.GetComponent<LineRenderer>());

                    DesactivarReceptorCristal();
                    DesactivarCristalPrisma();
                    receptor = null;
                    cristal = null;
                    prisma = null;
                }
                else if (hit.collider.gameObject.tag == "DirCheckI")
                {
                    angular = hit.collider.gameObject.transform.parent.gameObject;
                    angular.GetComponent<Angular>().EncendidoI = true;

                    angular.GetComponent<Angular>().LastLaser(FirePointPrismaR.GetComponent<LineRenderer>());

                    DesactivarReceptorCristal();
                    DesactivarCristalPrisma();
                    prisma = null;
                    receptor = null;
                    cristal = null;
                }
            }
            else if (hit.collider.gameObject.tag == "Receptor")
            {
                receptor = hit.collider.gameObject;

                hit.collider.gameObject.GetComponent<Receptor>().Encendido = true;
                receptor.GetComponent<Receptor>().LastLaser(FirePointPrismaR.GetComponent<LineRenderer>());

                DesactivarCristalPrisma();
                DesactivarAngularCristal();
                prisma = null;
                cristal = null;
                angular = null;
            }
            else if (hit.collider.gameObject.tag == "DirCheckF" || hit.collider.gameObject.tag == "DirCheckB")
            {
                if (hit.collider.gameObject.tag == "DirCheckF")
                {
                    cristal = hit.collider.gameObject.transform.parent.gameObject;
                    cristal.GetComponent<Cristal>().EncendidoB = true;

                    DesactivarAngularPrisma();
                    DesactivarAngularReceptor();
                    prisma = null;
                    receptor = null;
                    angular = null;

                }
                else if (hit.collider.gameObject.tag == "DirCheckB")
                {
                    cristal = hit.collider.gameObject.transform.parent.gameObject;
                    cristal.GetComponent<Cristal>().EncendidoF = true;
                    DesactivarAngularPrisma();
                    DesactivarAngularReceptor();
                    prisma = null;
                    receptor = null;
                    angular = null;
                }
            }
            else if (hit.collider.gameObject.tag == "Wall")
            {
                Desactivar();
            }

        }
        if (Physics.Raycast(FirePointPrismaL.transform.position, FirePointPrismaL.transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "DirCheckD" || hit.collider.gameObject.tag == "DirCheckI")
            {
                if (hit.collider.gameObject.tag == "DirCheckD")
                {
                    angular = hit.collider.gameObject.transform.parent.gameObject;
                    angular.GetComponent<Angular>().EncendidoD = true;

                    angular.GetComponent<Angular>().LastLaser(FirePointPrismaL.GetComponent<LineRenderer>());
                    DesactivarReceptorCristal();
                    DesactivarCristalPrisma();

                    prisma = null;
                    receptor = null;
                    cristal = null;
                }
                else if (hit.collider.gameObject.tag == "DirCheckI")
                {
                    angular = hit.collider.gameObject.transform.parent.gameObject;
                    angular.GetComponent<Angular>().EncendidoI = true;

                    angular.GetComponent<Angular>().LastLaser(FirePointPrismaL.GetComponent<LineRenderer>());

                    DesactivarReceptorCristal();
                    DesactivarCristalPrisma();
                    prisma = null;
                    receptor = null;
                    cristal = null;
                }
            }
            else if (hit.collider.gameObject.tag == "Receptor")
            {

                receptor = hit.collider.gameObject;

                hit.collider.gameObject.GetComponent<Receptor>().Encendido = true;
                receptor.GetComponent<Receptor>().LastLaser(FirePointPrismaL.GetComponent<LineRenderer>());

                DesactivarCristalPrisma();
                DesactivarAngularCristal();
                prisma = null;
                cristal = null;
                angular = null;
            }
            else if (hit.collider.gameObject.tag == "DirCheckF" || hit.collider.gameObject.tag == "DirCheckB")
            {
                if (hit.collider.gameObject.tag == "DirCheckF")
                {
                    cristal = hit.collider.gameObject.transform.parent.gameObject;
                    cristal.GetComponent<Cristal>().EncendidoB = true;
                    DesactivarAngularPrisma();
                    DesactivarAngularReceptor();
                    receptor = null;
                    angular = null;
                    prisma = null;
                }
                else if (hit.collider.gameObject.tag == "DirCheckB")
                {
                    cristal = hit.collider.gameObject.transform.parent.gameObject;
                    cristal.GetComponent<Cristal>().EncendidoF = true;
                    DesactivarAngularPrisma();
                    DesactivarAngularReceptor();
                    prisma = null;
                    receptor = null;
                    angular = null;
                }
            }
            else if (hit.collider.gameObject.tag == "Wall")
            {
                Desactivar();
            }

        }
        else
        {
            Desactivar();
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
            cristal.GetComponent<Cristal>().EncendidoF = false;
            cristal.GetComponent<Cristal>().EncendidoB = false;
        }
        else if (prisma != null)
        {
            prisma.GetComponent<Prisma>().Encendido = false;
        }
    }
}
