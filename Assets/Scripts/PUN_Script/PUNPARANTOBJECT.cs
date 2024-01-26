using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PUNPARANTOBJECT : MonoBehaviour
{
    int n = 0;
    GameObject camera;
    void Awake()
    {
        Debug.Log(transform.name);
        //PhotonNetwork.Instantiate("Sphere", this.transform.position, Quaternion.identity);
        //GameObject Sphere = GameObject.Find("PUNCHILDOBJECT");
        //Sphere.transform.parent = this.gameObject.transform;
       // Debug.Log("PUN_Share_Start");
        //camera = Camera.main.gameObject;
    }

    void Update()
    {/*
        if (n % 30 == 0)
        {
            //Debug.Log(this.transform.position - camera.transform.position);
            //Debug.Log("Parent_Update");
        }
        n++;
        */
    }
}
