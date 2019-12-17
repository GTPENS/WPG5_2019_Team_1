using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviourPun
{
    [SerializeField] private int  totalEnemy;
    [SerializeField] private int wave = 0;

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

    byte evCode = 1;

    public Transform[] spawnPoint = new Transform[7];
    public GameObject[] enemy = new GameObject[3];

    void Start()
    {
        totalEnemy = 40;
        redFire = redFireTotal[wave];
        blueFire = blueFireTotal[wave];
        blackFire = blackFireTotal[wave];
        whiteFire = whiteFireTotal[wave];
        //photonView.RPC("SpawnEnemy", RpcTarget.All);
        StartCoroutine(SpawnEnemy());
        //SpawnEnemy();
    }

    void Update()
    {
        //float spawnTime = Random.Range(1.0f, 3.0f);
        //while (spawnTime <= Time.deltaTime)
        //{
        //    SpawnEnemy();
        //}

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

                //SpawnEnemy();
                StartCoroutine(SpawnEnemy());
                //photonView.RPC("SpawnEnemy", RpcTarget.All);
            }
        }
        else
        {
            wave = 9;
        }
    }

    //void SpawnEnemy()
    //{
    //    bool isDone = false;

    //    int randomSpawn = Random.Range(0, 7);
    //    Vector2 spawnPos = spawnPoint[randomSpawn].transform.position;

    //    if (totalEnemy > 0)
    //    {
    //        do
    //        {
    //            int randomFire = Random.Range(0, 4);
    //            if (randomFire == 0 && redFire > 0)
    //            {
    //                PhotonNetwork.RaiseEvent(evCode, new object[] { "Red", spawnPos, Quaternion.identity }, true, 
    //                    new RaiseEventOptions() { Receivers = ReceiverGroup.All, CachingOption = EventCaching.AddToRoomCache });
    //                //PhotonNetwork.InstantiateSceneObject(enemy[randomFire].name, spawnPos, Quaternion.identity);
    //                totalEnemy--;
    //                redFire--;
    //                isDone = true;
    //            }
    //            else if (randomFire == 1 && blueFire > 0)
    //            {
    //                PhotonNetwork.InstantiateSceneObject(enemy[randomFire].name, spawnPos, Quaternion.identity);
    //                totalEnemy--;
    //                blueFire--;
    //                isDone = true;
    //            }
    //            else if (randomFire == 2 && blackFire > 0)
    //            {
    //                PhotonNetwork.InstantiateSceneObject(enemy[randomFire].name, spawnPos, Quaternion.identity);
    //                totalEnemy--;
    //                blackFire--;
    //                isDone = true;
    //            }
    //            else if (randomFire == 3 && whiteFire > 0)
    //            {
    //                PhotonNetwork.InstantiateSceneObject(enemy[randomFire].name, spawnPos, Quaternion.identity);
    //                totalEnemy--;
    //                whiteFire--;
    //                isDone = true;
    //            }
    //            else
    //            {
    //                isDone = false;
    //            }
    //        } while (!isDone);
    //    }
    //    else
    //    {
    //        waveCleared = true;
    //    }
    //}

    IEnumerator SpawnEnemy()
    {
        bool isDone = false;

        int randomSpawn = Random.Range(0, 7);
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
                    PhotonNetwork.Instantiate(enemy[randomFire].name, spawnPos, Quaternion.identity);
                    totalEnemy--;
                    redFire--;
                    isDone = true;
                }
                else if (randomFire == 1 && blueFire > 0)
                {
                    PhotonNetwork.Instantiate(enemy[randomFire].name, spawnPos, Quaternion.identity);
                    totalEnemy--;
                    blueFire--;
                    isDone = true;
                }
                else if (randomFire == 2 && blackFire > 0)
                {
                    PhotonNetwork.Instantiate(enemy[randomFire].name, spawnPos, Quaternion.identity);
                    totalEnemy--;
                    blackFire--;
                    isDone = true;
                }
                else if (randomFire == 3 && whiteFire > 0)
                {
                    PhotonNetwork.Instantiate(enemy[randomFire].name, spawnPos, Quaternion.identity);
                    totalEnemy--;
                    whiteFire--;
                    isDone = true;
                }
                else
                {
                    isDone = false;
                }
            } while (!isDone);
            //photonView.RPC("SpawnEnemy", RpcTarget.All);
            StartCoroutine(SpawnEnemy());
        }
        else
        {
            waveCleared = true;
        }
    }
}
