using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    private int animalIndex;
    private float spawnRangeX = 14f;
    private float spawnPosZ;

    [SerializeField, Range(2,5)]
    private float startDelay = 2f;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosZ = this.transform.position.z;
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }
    private void SpawnRandomAnimal()
    {
        //Posicion donde aparecera el animal
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        animalIndex = Random.Range(0, enemies.Length);

        Instantiate(enemies[animalIndex], spawnPos, enemies[animalIndex].transform.rotation);
    }
}
