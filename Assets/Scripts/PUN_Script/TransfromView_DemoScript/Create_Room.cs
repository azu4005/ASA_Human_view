using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; 
using Photon.Realtime; 

public class Create_Room : MonoBehaviourPunCallbacks
{

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("PUNSTART");

    }

    public override void OnConnectedToMaster()
    {
        RoomOptions options = new RoomOptions();
        options.PublishUserId = true;
        options.MaxPlayers = 4;
        PhotonNetwork.NickName = "Hololens2";
        PhotonNetwork.JoinOrCreateRoom("Room", options, TypedLobby.Default);
        Debug.Log("PUNCONNECT");
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("PUNJOINED");
        Debug.Log("PlayerNumber: " + PhotonNetwork.LocalPlayer.ActorNumber);
    }


}
