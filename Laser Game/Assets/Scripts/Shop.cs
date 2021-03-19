using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject nodos;
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
        nodos.gameObject.SetActive(false);
    }

    public void PurchaseAngular()
    {
        buildManager.SetComponentToBuild(buildManager.angularPrefab);
        nodos.gameObject.SetActive(true);
    }
    public void PurchasePrisma()
    {
        buildManager.SetComponentToBuild(buildManager.prismaPrefab);
        nodos.gameObject.SetActive(true);
    }
    public void PurchaseBlueCristal()
    {
        buildManager.SetComponentToBuild(buildManager.bluecristalPrefab);
        nodos.gameObject.SetActive(true);
    }
    public void PurchaseRedCristal()
    {
        buildManager.SetComponentToBuild(buildManager.redcristalPrefab);
        nodos.gameObject.SetActive(true);
    }
    public void PurchaseYellowCristal()
    {
        buildManager.SetComponentToBuild(buildManager.yellowcristalPrefab);
        nodos.gameObject.SetActive(true);
    }
}
