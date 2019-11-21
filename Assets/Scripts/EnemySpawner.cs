using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private int  totalEnemy = 3;
    private int wave = 0;
    private bool waveCleared = false;

    public static int getSpawnPoint;
    public Transform[] spawnPoint = new Transform[7];
    public GameObject[] enemy = new GameObject[3];

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
        if (totalEnemy <= 0 && waveCleared)
        {
            totalEnemy = 40;
            waveCleared = false;
            wave++;
        }
    }

    IEnumerator SpawnEnemy()
    {
        Debug.Log(totalEnemy.ToString());
        int randomSpawn = Random.Range(0, 7);
        getSpawnPoint = randomSpawn;
        Vector2 spawnPos = spawnPoint[randomSpawn].transform.position;

        float randomTime = Random.Range(1.0f, 3.0f);
        yield return new WaitForSeconds(randomTime);
        if (totalEnemy > 0)
        {
            totalEnemy--;
            Instantiate(enemy[3], spawnPos, Quaternion.identity);
            StartCoroutine(SpawnEnemy());
        }
    }
}
