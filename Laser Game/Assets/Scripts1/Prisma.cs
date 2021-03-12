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
    }

    // Update is called once per frame
    void Update()
    {
        if(Encendido == true)
        {
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
                Debug.Log("Entra en angular");
                if (hit.collider.gameObject.tag == "DirCheckD")
                {
                    angular = hit.collider.gameObject.transform.parent.gameObject;
                    Debug.Log(angular);
                    angular.GetComponent<Angular>().EncendidoD = true;

                    angular.GetComponent<Angular>().LastLaser(FirePointPrismaR.GetComponent<LineRenderer>());
                    receptor = null;
                    cristal = null;
                    prisma = null;
                }
                else if (hit.collider.gameObject.tag == "DirCheckI")
                {
                    angular = hit.collider.gameObject.transform.parent.gameObject;
                    Debug.Log(angular);
                    angular.GetComponent<Angular>().EncendidoI = true;
                    Debug.Log("Get Laser");

                    angular.GetComponent<Angular>().LastLaser(FirePointPrismaR.GetComponent<LineRenderer>());
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
                prisma = null;
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

                    prisma = null;
                    receptor = null;
                    angular = null;

                }
                else if (hit.collider.gameObject.tag == "DirCheckB")
                {
                    Debug.Log("Entra en collider dirCheckB Cristal");
                    cristal = hit.collider.gameObject.transform.parent.gameObject;
                    cristal.GetComponent<Cristal>().EncendidoF = true;
                    prisma = null;
                    receptor = null;
                    angular = null;
                }
            }

        }
        if (Physics.Raycast(FirePointPrismaL.transform.position, FirePointPrismaL.transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "DirCheckD" || hit.collider.gameObject.tag == "DirCheckI")
            {
                Debug.Log("Entra en angular");
                if (hit.collider.gameObject.tag == "DirCheckD")
                {
                    angular = hit.collider.gameObject.transform.parent.gameObject;
                    Debug.Log(angular);
                    angular.GetComponent<Angular>().EncendidoD = true;

                    angular.GetComponent<Angular>().LastLaser(FirePointPrismaL.GetComponent<LineRenderer>());
                    prisma = null;
                    receptor = null;
                    cristal = null;
                }
                else if (hit.collider.gameObject.tag == "DirCheckI")
                {
                    angular = hit.collider.gameObject.transform.parent.gameObject;
                    Debug.Log(angular);
                    angular.GetComponent<Angular>().EncendidoI = true;
                    Debug.Log("Get Laser");

                    angular.GetComponent<Angular>().LastLaser(FirePointPrismaL.GetComponent<LineRenderer>());
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
                prisma = null;
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


                    receptor = null;
                    angular = null;
                    prisma = null;
                }
                else if (hit.collider.gameObject.tag == "DirCheckB")
                {
                    Debug.Log("Entra en collider dirCheckB Cristal");
                    cristal = hit.collider.gameObject.transform.parent.gameObject;
                    cristal.GetComponent<Cristal>().EncendidoF = true;
                    prisma = null;
                    receptor = null;
                    angular = null;
                }
            }

        }
    }



    public void LastLaser(LineRenderer laser)
    {
        lr = laser;
    }
}
