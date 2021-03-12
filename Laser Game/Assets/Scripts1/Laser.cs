using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LineRenderer lr;


    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.useWorldSpace = false;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        
        if( Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "DirCheckI" || hit.collider.gameObject.tag == "DirCheckD")
            {
                lr.SetPosition(1, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + hit.distance + 0.9f));
                lr.SetPosition(0, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z));
                
            }
            else if (hit.collider.gameObject.tag == "DirCheckF" || hit.collider.gameObject.tag == "DirCheckB")
            {
                lr.SetPosition(1, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + hit.distance + 0.5f));
                lr.SetPosition(0, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z));

            }
            else if (hit.collider.gameObject.tag == "Prisma IN")
            {
                lr.SetPosition(1, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + hit.distance));
                lr.SetPosition(0, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z));
            }
            else
            {
                lr.SetPosition(1, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + hit.distance));
                lr.SetPosition(0, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z));

            }

        }
        else
        {
            lr.SetPosition(0, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z));
            lr.SetPosition(1, new Vector3(transform.localPosition.x, transform.localPosition.y,transform.localPosition.z + 5000));

        }

       
    }
}
