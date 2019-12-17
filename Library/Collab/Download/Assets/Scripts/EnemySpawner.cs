using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private int  totalEnemy;
    private int wave = 0;

    // Enemy per wave
    private int[] redFireTotal = { 40, 38, 36, 34, 32, 30, 28, 26, 24, 22 };
    private int[] blueFireTotal = { 0, 2, 4, 6, 7, 8, 9, 9, 9, 9 };
    private int[] blackFireTotal = { 0, 0, 0, 0, 1, 2, 3, 4, 5, 6 };
    private int[] whiteFireTotal = { 0, 0, 0, 0, 0, 0, 0, 1, 2, 3 };
    int redFire;
    int blueFire;
    int blackFire;
    int whiteFire;

    private bool waveCleared = false;

    public static int getSpawnPoint;
    public Transform[] spawnPoint = new Transform[7];
    public GameObject[] enemy = new GameObject[3];

    void Start()
    {
        redFire = redFireTotal[wave];
        blueFire = blueFireTotal[wave];
        blackFire = blackFireTotal[wave];
        whiteFire = whiteFireTotal[wave];
        StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
        if (wave < 9)
        {
            if (totalEnemy <= 0 && waveCleared)
            {
                waveCleared = false;
                wave++;
                totalEnemy = 40;

                redFire = redFireTotal[wave];
                blueFire = blueFireTotal[wave];
                blackFire = blackFireTotal[wave];
                whiteFire = whiteFireTotal[wave];

                StartCoroutine(SpawnEnemy());
            }
        }
        else
        {
            wave = 9;
        }
    }

    IEnumerator SpawnEnemy()
    {
        bool isDone = false;

        Debug.Log(totalEnemy.ToString());
        int randomSpawn = Random.Range(0, 7);
        getSpawnPoint = randomSpawn;
        Vector2 spawnPos = spawnPoint[randomSpawn].transform.position;

        float randomTime = Random.Range(1.0f, 3.0f);
        yield return new WaitForSeconds(randomTime);
        if (totalEnemy > 0)
        {
            do
            {
                int randomFire = Random.Range(0, 4);
                if (randomFire == 0 && redFire > 0)
                {
                    Instantiate(enemy[randomFire], spawnPos, Quaternion.identity);
                    totalEnemy--;
                    redFire--;
                    Debug.Log("Redfire : " + redFire.ToString());
                    isDone = true;
                }
                else if (randomFire == 1 && blueFire > 0)
                {
                    Instantiate(enemy[randomFire], spawnPos, Quaternion.identity);
                    totalEnemy--;
                    blueFire--;
                    Debug.Log("Bluefire : " + blueFire.ToString());
                    isDone = true;
                }
                else if (randomFire == 2 && blackFire > 0)
                {
                    Instantiate(enemy[randomFire], spawnPos, Quaternion.identity);
                    totalEnemy--;
                    blackFire--;
                    Debug.Log("Blackfire : " + blackFire.ToString());
                    isDone = true;
                }
                else if (randomFire == 3 && whiteFire > 0)
                {
                    Instantiate(enemy[randomFire], spawnPos, Quaternion.identity);
                    totalEnemy--;
                    whiteFire--;
                    Debug.Log("Whitefire : " + whiteFire.ToString());
                    isDone = true;
                }
                else
                {
                    isDone = false;
                }
            } while (!isDone);
            StartCoroutine(SpawnEnemy());
        }
        else
        {
            waveCleared = true;
        }
    }
}
