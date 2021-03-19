using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject angularPrefab;
    public GameObject prismaPrefab;
    public GameObject bluecristalPrefab;
    public GameObject redcristalPrefab;
    public GameObject yellowcristalPrefab;


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager in scene");
            return;
        }
        instance = this;
    }


    private GameObject componentToBuild;


    public GameObject GetComponentToBuild()
    {
        return componentToBuild;
    }

    public void SetComponentToBuild(GameObject component)
    {
        componentToBuild = component;

    }
}
