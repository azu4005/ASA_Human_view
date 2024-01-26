using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

//Photonviewプロパティを使うためにMonoBehaviourPunCallbacksを継承
public class AnimalShare : MonoBehaviourPunCallbacks
{
    GameObject Bard = GameObject.Find("bard");
    Vector3 targetPos;
    Vector3[] Position_List = new Vector3[4];

    private PhotonView photonview = null;
    private int flame = 0;

    void Awake()
    {
        
        targetPos = Bard.transform.position;
        photonview = GetComponent<PhotonView>();
        GameObject Parent = GameObject.Find("ParentAnchor");
        Debug.Log(Parent.transform);
        this.transform.parent = Parent.transform;
        Debug.Log(this.transform.parent);
    
    }

    // Update is called once per frame
    void Update()
    {
        flame = flame + 1;
        if (flame % 10 == 0)
        {
            var Dir = this.transform.parent.transform.position - targetPos;
            var PreRote = Quaternion.LookRotation(Dir);
            var Rote = Bard.transform.rotation;
            photonview.RPC("SyncPosition", RpcTarget.All,this.transform.parent.InverseTransformPoint(targetPos));
            photonview.RPC("SyncPosition", RpcTarget.All,this.transform.parent.InverseTransformPoint(targetPos),Quaternion.Inverse(PreRote));
            photonview.RPC("SyncPosition", RpcTarget.All, this.transform.parent.InverseTransformPoint(targetPos), this.transform.parent.InverseTransformDirection(Bard.transform.forward));
            flame = 0;
            Debug.Log(this.transform.position -  targetPos);
        }

    }

    [PunRPC]
    public void SyncPosition(Vector3 pos, Vector3 dir, PhotonMessageInfo info)
    {
        this.transform.localPosition = pos;
        //Debug.Log(info.Sender.ActorNumber);
        Vector3 ThisPos = this.transform.position;
        this.transform.position = ThisPos;
        this.transform.forward = this.transform.parent.TransformDirection(dir);
        //Debug.Log(this.transform.rotation);
    }

}

