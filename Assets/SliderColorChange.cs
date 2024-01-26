using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;

public class SliderColorChange : MonoBehaviourPunCallbacks
{
    int SliderSelected;
    private PhotonView photonview = null;
    // Start is called before the first frame update
    void Start()
    {
        SliderSelected = 0;
        photonview = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        photonview.RPC("SetSliderColor", RpcTarget.Others, SliderSelected);
    }

    public void OnFocus()
    {
        SliderSelected = 1;
    }


    public void OffFocus()
    {
        SliderSelected = 0;
    }

    [PunRPC]
    public void SetSliderColor(int OppositeSelected, PhotonMessageInfo info)
    {
        if(OppositeSelected == 1)
        {
            //GetComponent<Renderer>().material.color = Color.red;
        }
        else if(OppositeSelected == 0)
        {
            GetComponent<Renderer>().material.color = Color.black;
        }
    }
}
