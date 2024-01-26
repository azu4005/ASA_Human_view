using RosSharp.RosBridgeClient;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using System.Runtime.InteropServices;
//using HoloToolkit.Unity.InputModule;
using RosSharp.RosBridgeClient.MessageTypes.Std;

/*ORserver�ɒI�����̂̏���v��*/

public class StrPub : MonoBehaviour
{
    private RosSocket rosSocket;
    private string advertise_id;
    private RosSharp.RosBridgeClient.MessageTypes.Std.String message;
    //public int id;
    public string moji;

    public GameObject TriggerCube;
    TapTrigger taptrigger;
    private bool tapk = false;

    IDdecision iddecision;
    GameObject WorldEditorID;
    private int holoid;

    void Start()
    {
        WorldEditorID = GameObject.Find("WorldEditor");
        iddecision = WorldEditorID.GetComponent<IDdecision>();
        holoid = iddecision.ids;

        //TriggerCube = GameObject.Find("PressableButtonHoloLens2");
        taptrigger = TriggerCube.GetComponent<TapTrigger>();

        rosSocket = GetComponent<RosConnector>().RosSocket;
        //�g�s�b�N����chatter,�^��String
        advertise_id = rosSocket.Advertise<RosSharp.RosBridgeClient.MessageTypes.Std.String>("/chatter");
        moji = "none";
        message = new RosSharp.RosBridgeClient.MessageTypes.Std.String();
    }

    void Update()
    {
        tapk = taptrigger.tap;

        if (tapk == true)  //cube���^�b�v���ꂽ��
        {
            //this.gameObject.GetComponent<DBsubscriber>().num_check_topic = true;

            moji = "true";
            //Debug.Log("tap_triigerCube");
            message.data = moji;
            rosSocket.Publish(advertise_id, message);
            taptrigger.tap = false;
            tapk = false;
        }
    }
}