using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviourPun
{
    [SerializeField] int wave = 0;

    // Enemy per wave
    int[] redFireTotal = { 20, 18, 16, 14, 12, 10, 8, 6, 4, 2 };
    int[] blueFireTotal = { 0, 2, 4, 6, 7, 8, 9, 9, 9, 9 };
    int[] blackFireTotal = { 0, 0, 0, 0, 1, 2, 3, 4, 5, 6 };
    int[] whiteFireTotal = { 0, 0, 0, 0, 0, 0, 0, 1, 2, 3 };
    int totalEnemy;
    int redFire;
    int blueFire;
    int blackFire;
    int whiteFire;

    public Transform[] spawnPoint = new Transform[7];
    public GameObject[] enemy = new GameObject[3];
    public AudioClip roundFx;
    public AudioSource musicSource;
    public Text roundText;
    public GameObject roundInfo;

    void Start()
    {
        totalEnemy = 20;
        redFire = redFireTotal[wave];
        blueFire = blueFireTotal[wave];
        blackFire = blackFireTotal[wave];
        whiteFire = whiteFireTotal[wave];

        musicSource.clip = roundFx;

        photonView.RPC("ShowRound", RpcTarget.All, wave);
    }

    void Update()
    {
        
        if (totalEnemy <= 0 && GameManager.enemyDefeated >= 20)
        {
            if (wave < 9)
            {
                wave++;
                GameManager.enemyDefeated = 0;
                totalEnemy = 20;
                
                redFire = redFireTotal[wave];
                blueFire = blueFireTotal[wave];
                blackFire = blackFireTotal[wave];
                whiteFire = whiteFireTotal[wave];

                photonView.RPC("ShowRound", RpcTarget.All, wave);
            }
            else
            {
                photonView.RPC("WinCondition", RpcTarget.All);
            }
        }
    }

    [PunRPC]
    IEnumerator ShowRound(int round)
    {
        roundText.text = "Round " + (round + 1).ToString();
        roundInfo.SetActive(true);
        musicSource.Play();
        yield return new WaitForSeconds(2f);
        roundInfo.SetActive(false);

        StartCoroutine(SpawnEnemy());
    }

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
                    PhotonNetwork.InstantiateSceneObject(enemy[randomFire].name, spawnPos, Quaternion.identity);
                    totalEnemy--;
                    redFire--;
                    isDone = true;
                }
                else if (randomFire == 1 && blueFire > 0)
                {
                    PhotonNetwork.InstantiateSceneObject(enemy[randomFire].name, spawnPos, Quaternion.identity);
                    totalEnemy--;
                    blueFire--;
                    isDone = true;
                }
                else if (randomFire == 2 && blackFire > 0)
                {
                    PhotonNetwork.InstantiateSceneObject(enemy[randomFire].name, spawnPos, Quaternion.identity);
                    totalEnemy--;
                    blackFire--;
                    isDone = true;
                }
                else if (randomFire == 3 && whiteFire > 0)
                {
                    PhotonNetwork.InstantiateSceneObject(enemy[randomFire].name, spawnPos, Quaternion.identity);
                    totalEnemy--;
                    whiteFire--;
                    isDone = true;
                }
                else
                {
                    isDone = false;
                }
            } while (!isDone);

            Debug.Log(totalEnemy.ToString());
            StartCoroutine(SpawnEnemy());
        }
    }

    [PunRPC]
    public void WinCondition()
    {
        GameManager gm = GameObject.FindObjectOfType(typeof(GameManager)) as GameManager;
        gm.Win();
    }

}
