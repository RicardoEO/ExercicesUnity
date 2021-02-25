﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos;
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = this.transform.position;
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        if(!_playerController.gameOver)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
  
    }
}
