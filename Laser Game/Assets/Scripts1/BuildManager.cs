using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildMAnager in scene");
            return;
        }
        instance = this;
    }
    public GameObject angularPrefab;

    private void Start()
    {
        angularToBuild = angularPrefab;
    }

    private GameObject angularToBuild;

    public GameObject GetAngularToBuild()
    {
        return angularToBuild;
    }
}
