using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject cristal;
    public GameObject FirePoint;
    public GameObject angular;
    public GameObject receptor;

    public GameObject FirePointCristalF;
    public GameObject FirePointCristalB;

    void Start()
    {
        cristal = null;
        angular = null;
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
                Debug.Log(angular);
                angular.GetComponent<Angular>().EncendidoD = true;

                angular.GetComponent<Angular>().LastLaser(FirePoint.GetComponent<LineRenderer>());

                receptor = null;
                cristal = null;
            }
            else if (hit.collider.gameObject.tag == "DirCheckI")
            {
                angular = hit.collider.gameObject.transform.parent.gameObject;
                Debug.Log(angular);
                angular.GetComponent<Angular>().EncendidoI = true;

                angular.GetComponent<Angular>().LastLaser(FirePoint.GetComponent<LineRenderer>());

                receptor = null;
                cristal = null;
            }
            else if (hit.collider.gameObject.tag == "Receptor")
            {

                receptor = hit.collider.gameObject;

                hit.collider.gameObject.GetComponent<Receptor>().Encendido = true;

                angular = null;
                cristal = null;

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
                else if(hit.collider.gameObject.tag == "DirCheckB")
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
            if(angular != null)
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
