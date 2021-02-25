﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    private float topBound = 30f;

    private float lowerBound = -10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.z > topBound)
        {
            Destroy(this.gameObject);
        }

        if(this.transform.position.z < lowerBound)
        {
            UnityEngine.Debug.Log("Game Over");
            Destroy(this.gameObject);

            Time.timeScale = 0;

        }
    }
}
