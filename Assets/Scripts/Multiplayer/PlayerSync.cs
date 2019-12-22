using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSync : MonoBehaviourPun, IPunObservable
{
    Vector3 latestPos;
    Quaternion latestRot;

    public MonoBehaviour[] localScripts;

    void Awake()
    {
        if (photonView.IsMine)
        {
            // Local
        }
        else
        {
            //Player is Remote
            for (int i = 0; i < localScripts.Length; i++)
            {
                localScripts[i].enabled = false;
            }
        }
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            transform.position = Vector3.Lerp(transform.position, latestPos, Time.deltaTime * 10f);
            transform.rotation = Quaternion.Lerp(transform.rotation, latestRot, Time.deltaTime * 10f);
        }
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            latestPos = (Vector3)stream.ReceiveNext();
            latestRot = (Quaternion)stream.ReceiveNext();
        }
    }
}
