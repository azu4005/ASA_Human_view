using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.UI;
using System;
using UnityEngine.Events;
using Photon.Pun;
using Photon.Realtime;

public class ActiveHeadObject : MonoBehaviour
{
    private bool isActive;
    public GameObject player1;
    private GameObject[] Player = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber - 1);
    }
    public void Awake()
    {
        Player[0] = GameObject.Find("player1");
        Player[1] = GameObject.Find("player2");
    }

    // Update is called once per frame
    public void ActivePlayer()
    {
        if (isActive == false)
        {
            isActive = !isActive;
            Player[PhotonNetwork.LocalPlayer.ActorNumber - 1].SetActive(true);
            Debug.Log("Active head Object");
            

        }
        else
        {
            isActive = false;
            Player[PhotonNetwork.LocalPlayer.ActorNumber - 1].SetActive(false);
        }
        
    }
}
