using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpeed = 60;
    public float translateSpeed = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.left * translateSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
