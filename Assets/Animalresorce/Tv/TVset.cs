using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVset : MonoBehaviourPunCallbacks
{
    GameObject Rosconnecter;
    private PhotonView photonview = null;
    private GameObject TV;
    Vector3 KeepPos;
    int frame;

    // Start is called before the first frame update
    void Start()
    {
        Rosconnecter = GameObject.Find("rosconnecter");
        photonview = GetComponent<PhotonView>();
        TV = GameObject.Find("Tv_01");
    }

    // Update is called once per frame
    void Update()
    {


        frame++;
        if (frame % 20 == 0 && TV.activeInHierarchy == true)
        {
            photonview.RPC("TVSync", RpcTarget.Others, this.transform.parent.InverseTransformPoint(TV.transform.position), this.transform.parent.InverseTransformDirection(TV.transform.forward), this.transform.parent.InverseTransformDirection(TV.transform.up));
            //Debug.Log("RPC");
        }
       
    }


    [PunRPC]
    public void TVSync(Vector3 pos, Vector3 dirforward, Vector3 dirup, PhotonMessageInfo info)
    {
        //Debug.Log(this.transform.position);
        //Debug.Log("Get world position:" +pos);
        this.transform.localPosition = pos;
        this.transform.forward = this.transform.parent.TransformDirection(dirforward);
        dirforward = this.transform.forward;
        this.transform.up = this.transform.parent.TransformDirection(dirup);
        dirup = this.transform.up;
        this.transform.rotation = Quaternion.LookRotation(dirforward, dirup);
        KeepPos = this.transform.position;
        this.transform.position = KeepPos;
    }
}
