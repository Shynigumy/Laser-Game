using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject FirePoint;
    public GameObject angular;
    public GameObject receptor;
   


    void Start()
    {
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
            if (hit.collider.gameObject.tag == "Enemy")
            {
                angular = hit.collider.gameObject;

                hit.collider.gameObject.GetComponent<Angular>().Encendido = true;

                angular.GetComponent<Angular>().LastLaser(FirePoint.GetComponent<LineRenderer>());

                receptor = null;
            }
            else if (hit.collider.gameObject.tag == "Receptor")
            {

                receptor = hit.collider.gameObject;

                hit.collider.gameObject.GetComponent<Receptor>().Encendido = true;

                angular = null;

            }


        }
        else  
        {
            if(angular != null)
            {
                angular.GetComponent<Angular>().Encendido = false;
            }
            else if (receptor != null)
            {
                receptor.GetComponent<Receptor>().Encendido = false;
            }

        }
    }
}
