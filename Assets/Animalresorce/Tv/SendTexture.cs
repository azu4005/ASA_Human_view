using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SendTexture : MonoBehaviour
{
    [SerializeField] GameObject TV;
    private PhotonView photonview = null;
    public MeshRenderer TVmaterial;
        
    // Start is called before the first frame update
    void Start()
    {
        photonview = GetComponent<PhotonView>();
        TVmaterial = this.GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        TVmaterial = this.GetComponent<MeshRenderer>();

        if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {
            if (TV.activeInHierarchy == true)
            {
                photonview.RPC("Sendtexture", RpcTarget.Others, TVmaterial);

            }
        }
    }

    [PunRPC]
    public void Sendtexture(MeshRenderer mesh, PhotonMessageInfo info)
    {
        TVmaterial.material.SetColor("_Color", mesh.material.color);

    }
}
