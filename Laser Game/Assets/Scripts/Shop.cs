using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public int limitAngular;
    public int limitPrisma;
    public int limitBlueCristal;
    public int limitRedCristal;
    public int limitYellowCristal;

    public GameObject nodos;
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
        nodos.gameObject.SetActive(false);
    }

    public void PurchaseAngular()
    {
        if(limitAngular <= 0)
        {
            Debug.Log("You Can't Build!");
        }
        else
        {
            buildManager.SetComponentToBuild(buildManager.angularPrefab);
            nodos.gameObject.SetActive(true);

        }

    }
    public void PurchasePrisma()
    {
        if (limitPrisma <= 0)
        {
            Debug.Log("You Can't Build!");
        }
        else
        {
            buildManager.SetComponentToBuild(buildManager.prismaPrefab);
            nodos.gameObject.SetActive(true);

        }
    }
    public void PurchaseBlueCristal()
    {
        if (limitBlueCristal <= 0)
        {
            Debug.Log("You Can't Build!");
        }
        else
        {
            buildManager.SetComponentToBuild(buildManager.bluecristalPrefab);
            nodos.gameObject.SetActive(true);

        }
    }
    public void PurchaseRedCristal()
    {
        if (limitRedCristal <= 0)
        {
            Debug.Log("You Can't Build!");
        }
        else
        {
            buildManager.SetComponentToBuild(buildManager.redcristalPrefab);
            nodos.gameObject.SetActive(true);

        }
    }
    public void PurchaseYellowCristal()
    {
        if (limitYellowCristal <= 0)
        {
            Debug.Log("You Can't Build!");
        }
        else
        {
            buildManager.SetComponentToBuild(buildManager.yellowcristalPrefab);
            nodos.gameObject.SetActive(true);

        }
    }
}
