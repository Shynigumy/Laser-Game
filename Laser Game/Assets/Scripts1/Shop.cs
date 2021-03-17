using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseAngular()
    {
        buildManager.SetComponentToBuild(buildManager.angularPrefab);
    }
    public void PurchasePrisma()
    {
        buildManager.SetComponentToBuild(buildManager.prismaPrefab);
    }
    public void PurchaseBlueCristal()
    {
        buildManager.SetComponentToBuild(buildManager.bluecristalPrefab);
    }
    public void PurchaseRedCristal()
    {
        buildManager.SetComponentToBuild(buildManager.redcristalPrefab);
    }
    public void PurchaseYellowCristal()
    {
        buildManager.SetComponentToBuild(buildManager.yellowcristalPrefab);
    }
}
