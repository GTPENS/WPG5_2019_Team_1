using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MultiplayerSetup : MonoBehaviour
{
    public GameObject[] playerPrefabs;

    private void Awake()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(playerPrefabs[0].name, new Vector2(-5f, 0f), Quaternion.identity, 0);
        }
        else
        {
            PhotonNetwork.Instantiate(playerPrefabs[1].name, new Vector2(5f, 0f), Quaternion.identity, 0);
        }

        //for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++)
        //{
        //    PhotonNetwork.Instantiate(playerPrefabs[i].name, transform.position, Quaternion.identity);
        //}
    }
}
