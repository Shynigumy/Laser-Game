using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angular : MonoBehaviour
{
    public GameObject Parent;
    public GameObject cristal;
    public GameObject angular;
    public GameObject receptor;
    public GameObject FirePointAngular;
    public GameObject prisma;

    public GameObject MenuRotation;

    public GameObject Empty;
    public LineRenderer lr;

    public Collider DirCheckD;
    public Collider DirCheckI;


    public bool EncendidoD = false;
    public bool EncendidoI = false;
    void Start()
    {
        DirCheckD = gameObject.transform.GetChild(1).GetComponent<Collider>();
        DirCheckI = gameObject.transform.GetChild(2).GetComponent<Collider>();

        cristal = null;
        angular = null;
        receptor = null;
        prisma = null;

    }
    private void Awake()
    {
        MenuRotation.gameObject.SetActive(false);
    }

    void Update()
    {

        if (EncendidoD == true)
        {
            Empty.transform.localEulerAngles = new Vector3(0, this.transform.parent.gameObject.transform.localEulerAngles.y, -90 + this.transform.parent.gameObject.transform.localEulerAngles.z);
            DirCheckI.gameObject.SetActive(false);
            FirePointAngular.SetActive(true);
            Fire();

        }
        else if (EncendidoI == true)
        {
            Empty.transform.localEulerAngles = new Vector3(0, this.transform.parent.gameObject.transform.localEulerAngles.y, this.transform.parent.gameObject.transform.localEulerAngles.z);
            DirCheckD.gameObject.SetActive(false);
            FirePointAngular.SetActive(true);
            Fire();
            

        }
        else
        {
            Empty.transform.rotation = new Quaternion(0, Empty.transform.rotation.y, Empty.transform.rotation.z, 0);
            FirePointAngular.SetActive(false);
            DirCheckD.gameObject.SetActive(true);
            DirCheckI.gameObject.SetActive(true);

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

        if (Physics.Raycast(FirePointAngular.transform.position, FirePointAngular.transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "DirCheckD" || hit.collider.gameObject.tag == "DirCheckI")
            {
                if (hit.collider.gameObject.tag == "DirCheckD")
                {
                    angular = hit.collider.gameObject.transform.parent.gameObject;
                    angular.GetComponent<Angular>().EncendidoD = true;

                    angular.GetComponent<Angular>().LastLaser(FirePointAngular.GetComponent<LineRenderer>());

                    FirePointAngular.GetComponent<LineRenderer>().material = lr.material;
                    DesactivarReceptorCristal();
                    
                    receptor = null;
                    cristal = null;
                    prisma = null;
                }
                else if (hit.collider.gameObject.tag == "DirCheckI")
                {
                    angular = hit.collider.gameObject.transform.parent.gameObject;
                    angular.GetComponent<Angular>().EncendidoI = true;
                    angular.GetComponent<Angular>().LastLaser(FirePointAngular.GetComponent<LineRenderer>());

                    FirePointAngular.GetComponent<LineRenderer>().material = lr.material;
                    DesactivarReceptorCristal();
                   
                    receptor = null;
                    cristal = null;
                    prisma = null;
                }
            }
            else if (hit.collider.gameObject.tag == "Receptor")
            {

                receptor = hit.collider.gameObject;

                hit.collider.gameObject.GetComponent<Receptor>().Encendido = true;
                DesactivarAngularCristal();
                
                angular = null;
                cristal = null;
                prisma = null;
                receptor.GetComponent<Receptor>().LastLaser(FirePointAngular.GetComponent<LineRenderer>());

                FirePointAngular.GetComponent<LineRenderer>().material = lr.material;

            }
            else if (hit.collider.gameObject.tag == "DirCheckF")
            {
                cristal = hit.collider.gameObject.transform.parent.gameObject;

                cristal.GetComponent<Cristal>().EncendidoB = true;
                DesactivarAngularReceptor();
               
                cristal.GetComponent<Cristal>().LastLaser(FirePointAngular.GetComponent<LineRenderer>());

                FirePointAngular.GetComponent<LineRenderer>().material = lr.material;
                receptor = null;
                angular = null;
                prisma = null;
            }
            else if (hit.collider.gameObject.tag == "DirCheckB")
            {
                cristal = hit.collider.gameObject.transform.parent.gameObject;

                cristal.GetComponent<Cristal>().EncendidoF = true;
                DesactivarAngularReceptor();
                

                cristal.GetComponent<Cristal>().LastLaser(FirePointAngular.GetComponent<LineRenderer>());

                FirePointAngular.GetComponent<LineRenderer>().material = lr.material;

                receptor = null;
                angular = null;
                prisma = null;
            }
            else if (hit.collider.gameObject.tag == "Prisma IN")
            {
                prisma = hit.collider.gameObject;
                prisma.GetComponent<Prisma>().Encendido = true;
                DesactivarReceptorCristal();
                DesactivarAngularCristal();
                prisma.GetComponent<Prisma>().LastLaser(FirePointAngular.GetComponent<LineRenderer>());
                receptor = null;
                cristal = null;
                angular = null;
            }
            else if (hit.collider.gameObject.tag == "Wall")
            {
                Desactivar();
                FirePointAngular.GetComponent<LineRenderer>().material = lr.material;
            }
        }
        else
        {
            Desactivar();
            FirePointAngular.GetComponent<LineRenderer>().material = lr.material;
        }
    }
    public void RotacionHoraria()
    {
        EncendidoD = false;
        EncendidoI = false;
        Desactivar();
        Parent.transform.eulerAngles = new Vector3(Parent.transform.eulerAngles.x, Parent.transform.eulerAngles.y + 90, Parent.transform.eulerAngles.z);

    }
    public void RotacionAntiHoraria()
    {
        EncendidoD = false;
        EncendidoI = false;
        Desactivar();
        Parent.transform.eulerAngles = new Vector3(Parent.transform.eulerAngles.x, Parent.transform.eulerAngles.y - 90, Parent.transform.eulerAngles.z);

    }
    public void LastLaser(LineRenderer laser)
    {
        lr = laser;
    }

    public void DesactivarReceptorCristal()
    {
        FirePointAngular.GetComponent<LineRenderer>().material = lr.material;

        if (receptor != null)
        {
            receptor.GetComponent<Receptor>().Encendido = false;
        }
        if (cristal != null)
        {
            cristal.GetComponent<Cristal>().EncendidoF = false;
            cristal.GetComponent<Cristal>().EncendidoB = false;
        }
    }
    public void DesactivarAngularPrisma()
    {
        FirePointAngular.GetComponent<LineRenderer>().material = lr.material;

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
        FirePointAngular.GetComponent<LineRenderer>().material = lr.material;

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
        FirePointAngular.GetComponent<LineRenderer>().material = lr.material;
        if (prisma != null)
        {
            prisma.GetComponent<Prisma>().Encendido = false;
        }

        if (cristal != null)
        {
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