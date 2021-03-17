using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagadoLuces : MonoBehaviour
{
    public Light myLight;
    public float startTime;
    public bool changeIntensity = false;
    public float intensitySpeed = 1.0f;
    public float maxIntensity = 10.0f;
    public bool repeatIntensity = false;

    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (changeIntensity)
        {
            myLight.intensity -= intensitySpeed * Time.deltaTime;

            if (myLight.intensity >= maxIntensity)
            {
                changeIntensity = false;
               
            }
        }
    }
}
