using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class NetworkController : MonoBehaviourPunCallbacks
{
    public Text stateText;

    bool inRoom = false;

    void Start()
    {
        // Connects to Photon master servers
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        stateText.text = "We are now connected to the " + PhotonNetwork.CloudRegion + " server!";
    }

    public void JoinGame()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Room : " + PhotonNetwork.CurrentRoom);
        inRoom = true;
    }

    // Callback function for if we fail to join a rooom
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom();
    }

    // Trying to create our own room
    void CreateRoom()
    {
        Debug.Log("Creating room");
        int randomRoomNumber = Random.Range(0, 10000); //creating a random name for the room
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 2 };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps); //attempting to create a new room
        stateText.text = "Successful to create room";
        inRoom = true;
    }

    // Callback function for if we fail to create a room. Most likely fail because room name was taken.
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        CreateRoom(); // Retrying to create a new room with a different name.
    }

    private void Update()
    {
        if (inRoom)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                PhotonNetwork.LoadLevel("Gameplay");
                inRoom = false;
            }
            else if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                stateText.text = "Waiting for other player";
            }
        }
    }
}
