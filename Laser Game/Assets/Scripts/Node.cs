﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private GameObject Component;
    private GameObject Angular;
    private GameObject Cristal;
    private GameObject Prisma;
    public GameObject ShopGO;

    private Renderer rend;
    private Color startColor;
    public GameObject nodos;

    public bool Ocupado;

    BuildManager buildManager;
    private void Start()
    {
        Ocupado = false;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }
    private void OnMouseDown()
    {
        if (buildManager.GetComponentToBuild() == null)
            return;
        if(Ocupado == true)
        {
            Debug.Log("Can't build there!");
            return;
        }

        GameObject componentToBuild = BuildManager.instance.GetComponentToBuild();
        Component = (GameObject)Instantiate(componentToBuild, transform.position, transform.rotation);
        if (Component.name.Contains("Angular"))
        {
            ShopGO.GetComponent<Shop>().limitAngular--;
        }
        if (Component.name.Contains("prisma"))
        {
            ShopGO.GetComponent<Shop>().limitPrisma--;
        }
        if (Component.name.Contains("Blue"))
        {
            ShopGO.GetComponent<Shop>().limitBlueCristal--;
        }
        if (Component.name.Contains("Red"))
        {
            ShopGO.GetComponent<Shop>().limitRedCristal--;
        }
        if (Component.name.Contains("Yellow"))
        {
            ShopGO.GetComponent<Shop>().limitYellowCristal--;
        }
        Ocupado = true;
        nodos.gameObject.SetActive(false);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetComponentToBuild() == null)
            return;
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
