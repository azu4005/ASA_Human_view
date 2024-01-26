using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Switch_Rosconnecter : MonoBehaviourPunCallbacks
{
    [SerializeField]  GameObject Rosconnecter;
    [SerializeField]  GameObject TV;
    private PhotonView photonview = null;
    int frame;

    // Start is called before the first frame update
    void Start()
    {
        //Rosconnecter = GameObject.Find("rosconnecter");
        //TV = GameObject.Find("Tv_01");
        photonview = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {

        if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {
            if (Rosconnecter.activeSelf == true)
            {
                photonview.RPC("RosTrue", RpcTarget.Others);

            }
            else
            {

                photonview.RPC("RosFalse", RpcTarget.All);

            }
        }
    

    }


    [PunRPC]
    public void RosTrue(PhotonMessageInfo info)
    {
         Rosconnecter.SetActive(true);

    }

    [PunRPC]
    public void RosFalse(PhotonMessageInfo info)
    {
        Rosconnecter.SetActive(false);
        TV.SetActive(false);

    }


}