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
            if (hit.collider)
            {
                lr.SetPosition(1, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + hit.distance + 0.5f));
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
