using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    public GameObject RotMenu;
    public Collider TopCollider;
    private void Start()
    {
        RotMenu.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform != null)
                {
                    if(hit.transform.tag == "Clicker")
                    {
                        RotMenu.gameObject.SetActive(true);
                        TopCollider.GetComponent<Collider>().gameObject.SetActive(false);
                    }
                }
                else
                {
                    RotMenu.gameObject.SetActive(false);
                    TopCollider.GetComponent<Collider>().gameObject.SetActive(true);
                }
            }
        }
    
    }

}
