using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesplazamientoCamara : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public float speed;

    private void Start()
    {
        transform.position = startPos.position;
    }
    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPos.position, step);
    }
}
