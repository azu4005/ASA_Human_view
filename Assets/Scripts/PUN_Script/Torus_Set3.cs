using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Torus_Set3 : MonoBehaviourPunCallbacks
{

    [SerializeField]
    GameObject Torus2;
    GameObject targetObject;
    Vector3 pos;
    Vector3 dirforward;
    Vector3 dirup;
    Vector3 KeepPos;
    MeshRenderer mr;
    string Myname;
    private bool isAvailable;


    // Start is called before the first frame update
    void Start()
    {
        targetObject = Camera.main.gameObject;

        mr = GetComponent<MeshRenderer>();


        if(this.transform.parent == null)
        {
            this.transform.parent = GameObject.Find("ParentAnchor").transform;
        }


        isAvailable = true;

      
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (isAvailable)
        {
            isAvailable = false;

            if (Myname == "My name is 1")
            {
                mr.material.color = new Color32(255, 0, 0, 255);
            }
            else if (Myname == "My name is 2")
            {
                mr.material.color = new Color32(0, 255, 0, 255);
            }
            else if (Myname == "My name is 3")
            {
                mr.material.color = new Color32(0, 0, 255, 255);
            }
       
        }
        */

        Myname = PhotonNetwork.LocalPlayer.NickName;
        
        if (isAvailable)
        {
            isAvailable = false;

            if (Myname == "My name is 2")
            {
                this.gameObject.GetComponent<PhotonView>().RequestOwnership();
            }
        }



        if (Myname == "My name is 2")
        {

            pos = this.transform.parent.InverseTransformPoint(targetObject.transform.position);
            dirforward = this.transform.parent.InverseTransformDirection(targetObject.transform.forward);
            dirup = this.transform.parent.InverseTransformDirection(targetObject.transform.up);

            this.transform.localPosition = pos;
            this.transform.forward = this.transform.parent.TransformDirection(dirforward);
            dirforward = this.transform.forward;
            this.transform.up = this.transform.parent.TransformDirection(dirup);
            dirup = this.transform.up;
            this.transform.rotation = Quaternion.LookRotation(dirforward, dirup);
            KeepPos = this.transform.position;
            KeepPos.y += 0.3f;
            this.transform.position = KeepPos;
        }


    }

}
