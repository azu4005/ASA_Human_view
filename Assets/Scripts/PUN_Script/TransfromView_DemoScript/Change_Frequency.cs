using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Change_Frequency : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update


    public void ChangeRate11() 
    {
        PhotonNetwork.SendRate = 1; // 1秒間にメッセージ送信を行う回数
        PhotonNetwork.SerializationRate = 1; // 1秒間にオブジェクト同期を行う回数

        Debug.Log("SendRate = 1, SerializationRate = 1");
    }
    public void ChangeRate1510()
    {
        PhotonNetwork.SendRate = 15; // 1秒間にメッセージ送信を行う回数
        PhotonNetwork.SerializationRate = 10; // 1秒間にオブジェクト同期を行う回数

        Debug.Log("SendRate = 15, SerializationRate = 10");
    }

    public void ChangeRate1030()
    {
        PhotonNetwork.SendRate = 5; // 1秒間にメッセージ送信を行う回数
        PhotonNetwork.SerializationRate = 30; // 1秒間にオブジェクト同期を行う回数

        Debug.Log("SendRate = 5, SerializationRate = 30");
    }


    public void ChangeRate3005()
    {
        PhotonNetwork.SendRate = 30; // 1秒間にメッセージ送信を行う回数
        PhotonNetwork.SerializationRate = 5; // 1秒間にオブジェクト同期を行う回数

        Debug.Log("SendRate = 30, SerializationRate = 5");
    }

    public void ChangeRate6030()
    {
        PhotonNetwork.SendRate = 60; // 1秒間にメッセージ送信を行う回数
        PhotonNetwork.SerializationRate = 60; // 1秒間にオブジェクト同期を行う回数
        Debug.Log("SendRate = 60, SerializationRate = 60");
    }

    public void ChangeSendRate()
    {
        PhotonNetwork.SendRate = 60; // 1秒間にメッセージ送信を行う回数
        PhotonNetwork.SerializationRate = 10; // 1秒間にオブジェクト同期を行う回数
        Debug.Log("SendRate = 60, SerializationRate = 10");
    }

    public void ChangeSerializationRate()
    {
        PhotonNetwork.SendRate = 30; // 1秒間にメッセージ送信を行う回数
        PhotonNetwork.SerializationRate = 30; // 1秒間にオブジェクト同期を行う回数

        Debug.Log("SendRate =30, SerializationRate = 30");
    }

    public void ChangeDefaultRate()
    {
        PhotonNetwork.SendRate = 30; // 1秒間にメッセージ送信を行う回数
        PhotonNetwork.SerializationRate = 10; // 1秒間にオブジェクト同期を行う回数

        Debug.Log("SendRate =30, SerializationRate = 10");
    }

    public void ChangeRate100()
    {
        PhotonNetwork.SendRate = 100; // 1秒間にメッセージ送信を行う回数
        PhotonNetwork.SerializationRate = 100; // 1秒間にオブジェクト同期を行う回数

        Debug.Log("SendRate =100, SerializationRate = 100");
    }
}
