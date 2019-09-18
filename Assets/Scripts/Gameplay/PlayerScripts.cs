using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerScripts : MonoBehaviourPun, IPunObservable
{
    public PhotonView pv;

    public float moveSpeed = 10, jumpForce = 800;

    private Vector3 smoothMove;

    private GameObject sceneCamera;
    public GameObject playerCamera;
    public SpriteRenderer sr;

    private void Start()
    {
        if(photonView.IsMine)
        {
            sceneCamera = GameObject.Find("Main Camera");
            sceneCamera.SetActive(false);
            playerCamera.SetActive(true);
        }
        
    }

    private void Update()
    {
        if(photonView.IsMine)
        {
            ProcessInputs();
        }
     else
       {
            SmoothMovement();
        }
    }

    private void SmoothMovement()
    {
        transform.position = Vector3.Lerp(transform.position, smoothMove, Time.deltaTime * 10);
        
    }

    private void ProcessInputs()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"),0);
        transform.position += move * moveSpeed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            sr.flipX = false;
            //pv.RPC("OnDirectionChange_RIGHT", RpcTarget.Others);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            //pv.RPC("OnDirectionChange_LEFT", RpcTarget.Others);
        }

    }

    //[PunRPC]
    //void OnDirectionChange_LEFT()
    //{
      //  sr.flipX = true;
    //}

    //[PunRPC]
    //void OnDirectionChange_RIGHT()
    //{
      //  sr.flipX = false;
    //}

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(transform.position);
        }
        else if (stream.IsReading)
        {
            smoothMove = (Vector3) stream.ReceiveNext();
        }
    }
}
