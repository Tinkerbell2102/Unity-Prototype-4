using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spwanRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefab;

    // Start is called before the first frame update
    void Start()
    {
        spwanEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPos(), powerupPrefab.transform.rotation);
    }

    void spwanEnemyWave(int EnemiesToSpwan) 
    {
        for (int i = 0; i < EnemiesToSpwan; i++) 
        { 
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            spwanEnemyWave(waveNumber++); spwanEnemyWave(waveNumber) ;
        }
        if (enemyCount == 0)
        {
            Instantiate(powerupPrefab, GenerateSpawnPos(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPos()
    {
        float spwanPosX = Random.Range(-spwanRange, spwanRange);
        float spwanPosZ = Random.Range(-spwanRange, spwanRange);
        Vector3 randomPos = new Vector3(spwanPosX, 0, spwanPosZ);
        return randomPos;
    }
}
