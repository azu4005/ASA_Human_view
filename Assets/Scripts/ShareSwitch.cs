using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;

public class ShareSwitch : MonoBehaviourPunCallbacks
{
    private int flag;
    private int changeflag;
    public static int Share = 0;
    float mid;
    float max;
    float min;
    Vector3 ThisPos;
    Quaternion ThisRote;
    Vector3 KeepPos;
    Vector3 LastReceive;
    public GameObject ShareText;
    GameObject targetObject;
    GameObject Child;
    GameObject Ros;
    GameObject plane1;
    private PhotonView photonview = null;

    // Start is called before the first frame update
    void Start()
    {
        //Ros = GameObject.Find("rosconnecter");
        targetObject = Camera.main.gameObject;
        //ShareText = GameObject.Find("ShareText");
        photonview = GetComponent<PhotonView>();
        mid = 0f;
        min = -0.1f;
        max = 0.1f;
        changeflag = 0;
        ThisPos = this.transform.localPosition;
        ThisRote = this.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        ThisPos.x = this.transform.localPosition.x;
        if (ThisPos.x < min)
        {
            ThisPos.x = min;
        }
        else if (ThisPos.x > max)
        {
            ThisPos.x = max;
        }
        if (flag % 40 == 0)
        {
            if (ThisPos.x < mid)
            {
                ThisPos.x = min;
            }
            else if (ThisPos.x > mid)
            {
                ThisPos.x = max;
            }
        }

        if (ThisPos.x > mid)
        {
            Share = 0;
            ShareText.GetComponent<TextMesh>().text = ("LocalMode");
            ShareText.GetComponent<TextMesh>().color = Color.black;
        }
        else
        {
            Share = 1;
            ShareText.GetComponent<TextMesh>().text = ("ShareMode");
            ShareText.GetComponent<TextMesh>().color = Color.green;
        }
        if (Share == 1 && flag % 1 == 0)
        {
            bool lastbool = false;
            photonview.RPC("SyncPosition", RpcTarget.Others, this.transform.parent.InverseTransformPoint(targetObject.transform.position), this.transform.parent.InverseTransformDirection(targetObject.transform.forward), this.transform.parent.InverseTransformDirection(targetObject.transform.up), Share, DBsubscriber.pinchslider, Slider.thispos, changeflag, lastbool, Admin.adminflag);

        }
        this.transform.localPosition = ThisPos;
        this.transform.localRotation = ThisRote;
        flag++;
    }

    [PunRPC]
    public void SyncPosition(Vector3 pos, Vector3 dirforward, Vector3 dirup, int share, float getslider, Vector3 getPos, int change, bool last, int Adflag, PhotonMessageInfo info)
    {

        if (Share == 1)
        {
            if (Adflag == 1)
            {
                Admin.adminflag = 0;
            }
            Slider.Shareflag = 1;
            Slider.GetPos = getPos;
            LastReceive = getPos;

        }

    }
}
