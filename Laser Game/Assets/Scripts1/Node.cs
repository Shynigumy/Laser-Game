using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    private GameObject Angular;


    private Renderer rend;
    private Color startColor;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    private void OnMouseDown()
    {
        if(Angular != null)
        {
            Debug.Log("Can't build there!");
            return;
        }
        GameObject angularToBuild = BuildManager.instance.GetAngularToBuild();
        Angular = (GameObject)Instantiate(angularToBuild, transform.position, transform.rotation);
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
