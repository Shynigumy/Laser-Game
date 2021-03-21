using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionNave : MonoBehaviour
{

    public float X = 15f;
    public float Y = -15f;
    public float Z = -10f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(X, Y, Z) * Time.deltaTime);
    }
}
