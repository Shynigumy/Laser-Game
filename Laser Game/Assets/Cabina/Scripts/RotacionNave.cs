using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionNave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15f, -15f, -10f) * Time.deltaTime);
    }
}
