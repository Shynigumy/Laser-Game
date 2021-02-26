using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angular : MonoBehaviour
{
    public GameObject angular;
    public GameObject receptor;
    public GameObject FirePointAngular;
    public LineRenderer lr;

    public bool Encendido = false;

    void Start()
    {
        receptor = null;
    }

    void Update()
    {

        if (Encendido == true)
        {
            
            FirePointAngular.SetActive(true);
            Fire();

        }
        else
        {
            FirePointAngular.SetActive(false);

            if (angular != null)
            {
                angular.GetComponent<Angular>().Encendido = false;
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

        if (Physics.Raycast(FirePointAngular.transform.position, FirePointAngular.transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {

                angular = hit.collider.gameObject;

                hit.collider.gameObject.GetComponent<Angular>().Encendido = true;
                receptor = null;
                angular.GetComponent<Angular>().LastLaser(FirePointAngular.GetComponent<LineRenderer>());

                FirePointAngular.GetComponent<LineRenderer>().material = lr.material;
            }
            else if (hit.collider.gameObject.tag == "Receptor")
            {

                receptor = hit.collider.gameObject;

                hit.collider.gameObject.GetComponent<Receptor>().Encendido = true;
                angular = null;
                receptor.GetComponent<Receptor>().LastLaser(FirePointAngular.GetComponent<LineRenderer>());

                FirePointAngular.GetComponent<LineRenderer>().material = lr.material;

            }

        }
        else
        {
            FirePointAngular.GetComponent<LineRenderer>().material = lr.material;

            if (angular != null)
            {
                angular.GetComponent<Angular>().Encendido = false;
            }
            else if (receptor != null)
            {
                receptor.GetComponent<Receptor>().Encendido = false;
            }
        }


        

    }
    public void LastLaser(LineRenderer laser)
    {
        lr = laser;
    }
}
