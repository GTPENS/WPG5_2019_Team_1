using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSync : MonoBehaviourPun, IPunObservable
{
    public MonoBehaviour[] localScripts;
    Vector3 latestPos;
    Vector3 latestRot;

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

    void FixedUpdate()
    {
        if (!photonView.IsMine)
        {
            transform.position = Vector3.Lerp(transform.position, latestPos, Time.fixedDeltaTime);
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, latestRot, Time.fixedDeltaTime);
        }
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.eulerAngles);
        }
        else
        {
            latestPos = (Vector3)stream.ReceiveNext();
            latestRot = (Vector3)stream.ReceiveNext();

            //float lag = Mathf.Abs((float)(PhotonNetwork.Time - info.timestamp)); 
            //latestPos += (_rb.velocity * lag);
        }
    }
}
