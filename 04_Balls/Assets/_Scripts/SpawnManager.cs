using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int enemyWave = 1;

    public GameObject powerUpPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(enemyWave);
  
    }

    void SpawnEnemyWave(int numberOfEnemies)
    {
        for(int i=0; i < numberOfEnemies; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            enemyWave++;
            SpawnEnemyWave(enemyWave);
            int numberOfPowerUps = Random.Range(0,3);
            for(int i = 0; i < numberOfPowerUps; i++)
            {
                Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
            }
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
