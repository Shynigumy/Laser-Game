using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int limitAngular;
    public int limitPrisma;
    public int limitBlueCristal;
    public int limitRedCristal;
    public int limitYellowCristal;

    public Text angularLimit;
    public Text prismaLimit;
    public Text cristalBlueLimit;
    public Text cristalRedLimit;
    public Text cristalYellowLimit;

    public int limitAux;

    public GameObject nodos;
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
        nodos.gameObject.SetActive(false);
        angularLimit.text = limitAngular.ToString();
        prismaLimit.text = limitPrisma.ToString();
        cristalBlueLimit.text = limitBlueCristal.ToString();
        cristalRedLimit.text = limitRedCristal.ToString();
        cristalYellowLimit.text = limitYellowCristal.ToString();
    }

    public void PurchaseAngular()
    {
        limitAux = limitAngular;

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
        limitAux = limitPrisma;
        
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
        limitAux = limitBlueCristal;
        
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
        limitAux = limitRedCristal;
        
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
        limitAux = limitYellowCristal;
        
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
