using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private int  totalEnemy = 40;

    public Transform[] spawnPoint = new Transform[7];
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        Debug.Log(totalEnemy.ToString());
        int randomSpawn = Random.Range(0, 7);
        Debug.Log(randomSpawn.ToString());
        Vector2 spawnPos = spawnPoint[randomSpawn].transform.position;
        //spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemy, spawnPos, Quaternion.identity);
        float randomTime = Random.Range(1.0f, 3.0f);
        yield return new WaitForSeconds(randomTime);
        if (totalEnemy > 1)
        {
            totalEnemy--;
            StartCoroutine(SpawnEnemy());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
