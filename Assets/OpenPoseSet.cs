using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using RosSharp.RosBridgeClient;
using Microsoft.MixedReality.Toolkit.UI;
using RosSharp.RosBridgeClient.MessageTypes.DetectObject;
using UnityEngine;

public class OpenPoseSet : MonoBehaviourPunCallbacks
{
    private PhotonView photonview = null;

    private int FPSAdjust = 0;

    private GameObject[] BodyParts = new GameObject[18];
    public GameObject Nose;
    public GameObject Neck;
    public GameObject RShoulder;
    public GameObject RElbow;
    public GameObject RWrist;
    public GameObject LShoulder;
    public GameObject LElbow;
    public GameObject LWrist;
    public GameObject RHip;
    public GameObject RKnee;
    public GameObject RAnkle;
    public GameObject LHip;
    public GameObject LKnee;
    public GameObject LAnkle;
    public GameObject REye;
    public GameObject LEye;
    public GameObject REar;
    public GameObject LEar;

    private Vector3[] PersonPose = new Vector3[18];
    private Vector3 NosePos;
    private Vector3 NeckPos;
    private Vector3 RShoulderPos;
    private Vector3 RElbowPos;
    private Vector3 RWristPos;
    private Vector3 LShoulderPos;
    private Vector3 LElbowPos;
    private Vector3 LWristPos;
    private Vector3 RHipPos;
    private Vector3 RKneePos;
    private Vector3 RAnklePos;
    private Vector3 LHipPos;
    private Vector3 LKneePos;
    private Vector3 LAnklePos;
    private Vector3 REyePos;
    private Vector3 LEyePos;
    private Vector3 REarPos;
    private Vector3 LEarPos;

    private float[] PoseScore = new float[18];
    private float NoseScore;
    private float NeckScore;
    private float RShoulderScore;
    private float RElbowScore;
    private float RWristScore;
    private float LShoulderScore;
    private float LElbowScore;
    private float LWristScore;
    private float RHipScore;
    private float RKneeScore;
    private float RAnkleScore;
    private float LHipScore;
    private float LKneeScore;
    private float LAnkleScore;
    private float REyeScore;
    private float LEyeScore;
    private float REarScore;
    private float LEarScore;



    private int[] DepthList = new int[18];

    private bool UpdateFlag;

    private bool OffLineMode;

    private bool HaveData;

    private int MaxFrame = 2;

    private Vector3[,] PosList;

    private RosSocket rosSocket;

    public static float getslider;

    private int AdjustSlider;

    // Start is called before the first frame update
    void Start()
    {
        photonview = GetComponent<PhotonView>();
        BodyParts[0] = Nose;
        BodyParts[1] = Neck;
        BodyParts[2] = RShoulder;
        BodyParts[3] = RElbow;
        BodyParts[4] = RWrist;
        BodyParts[5] = LShoulder;
        BodyParts[6] = LElbow;
        BodyParts[7] = LWrist;
        BodyParts[8] = RHip;
        BodyParts[9] = RKnee;
        BodyParts[10] = RAnkle;
        BodyParts[11] = LHip;
        BodyParts[12] = LKnee;
        BodyParts[13] = LAnkle;
        BodyParts[14] = REye;
        BodyParts[15] = LEye;
        BodyParts[16] = REar;
        BodyParts[17] = LEar;

        PersonPose[0] = NosePos;
        PersonPose[1] = NeckPos;
        PersonPose[2] = RShoulderPos;
        PersonPose[3] = RElbowPos;
        PersonPose[4] = RWristPos;
        PersonPose[5] = LShoulderPos;
        PersonPose[6] = LElbowPos;
        PersonPose[7] = LWristPos;
        PersonPose[8] = RHipPos;
        PersonPose[9] = RKneePos;
        PersonPose[10] = RAnklePos;
        PersonPose[11] = LHipPos;
        PersonPose[12] = LKneePos;
        PersonPose[13] = LAnklePos;
        PersonPose[14] = REyePos;
        PersonPose[15] = LEyePos;
        PersonPose[16] = REarPos;
        PersonPose[17] = LEarPos;

        PoseScore[0] = NoseScore;
        PoseScore[1] = NeckScore;
        PoseScore[2] = RShoulderScore;
        PoseScore[3] = RElbowScore;
        PoseScore[4] = RWristScore;
        PoseScore[5] = LShoulderScore;
        PoseScore[6] = LElbowScore;
        PoseScore[7] = LWristScore;
        PoseScore[8] = RHipScore;
        PoseScore[9] = RKneeScore;
        PoseScore[10] = RAnkleScore;
        PoseScore[11] = LHipScore;
        PoseScore[12] = LKneeScore;
        PoseScore[13] = LAnkleScore;
        PoseScore[14] = REyeScore;
        PoseScore[15] = LEyeScore;
        PoseScore[16] = REarScore;
        PoseScore[17] = LEarScore;

        PosList = new Vector3[18, MaxFrame];


        for (int i = 0; i <= 17; i++)
        {
            DepthList[i] = 0;
        }

        UpdateFlag = false;

        OffLineMode = true;

        if (OffLineMode)
        {
            Debug.Log("OffLineMode");
            for (int i = 0; i <= 17; i++)
            {
                PosList[i, 0] = BodyParts[i].transform.localPosition;
                PosList[i, 1] = BodyParts[i].transform.localPosition;
            }
        }
        else
        {
            Debug.Log("NotOffLineMode");
            Invoke("Init", 1.0f);
        }
        for (int i = 0; i <= 17; i++)
        {
            Debug.Log(BodyParts[i].transform.position);
        }

        PosList[4, 1] = new Vector3(PosList[4, 1].x, PosList[0, 1].y, PosList[0, 1].y);
        PosList[7, 1] = new Vector3(PosList[4, 1].x, -0.8f, -1f);
    }

    public void Init()
    {
        //rosSocket = GetComponent<RosConnector>().RosSocket;
        //rosSocket.Subscribe<DBinfo>("/shelfDB", GetData, 0);

    }

    void GetData(DBinfo message)
    {
        DBinfo Data = (DBinfo)message;
        //ïœêîópà”ÇµÇƒäiî[Ç∑ÇÈÅB
        HaveData = true;
    }


    // Update is called once per frame
    void Update()
    {
        AdjustSlider = (int)(getslider * (MaxFrame - 1) / 2);
        Debug.Log(getslider);
        Debug.Log(AdjustSlider);
        if (FPSAdjust % 10 == 0)
        {
            if (OffLineMode)
            {
                for (int i = 0; i <= 17; i++)
                {
                    PersonPose[i] = PosList[i, AdjustSlider];
                }
            }
            else
            {

            }
            for (int i = 0; i <= 17; i++)
            {
                BodyParts[i].transform.localPosition = PersonPose[i];
            }
            FPSAdjust = 0;
        }
        FPSAdjust++;
    }

    private void ConvDepthInfoToScale(int ObjectNumber, int IntDepth)
    {
        PersonPose[ObjectNumber].z = (float)IntDepth;
    }

    public void SendDepth(int[] IntDepthList)
    {
        for (int i = 0; i <= 17; i++)
        {
            ConvDepthInfoToScale(i, IntDepthList[i]);
        }
    }

    public void OpenPoseUpdate(Vector3[] PoseList)
    {
        for (int i = 0; i <= 17; i++)
        {
            BodyParts[i].transform.localPosition = PoseList[i];
        }
    }

    [PunRPC]
    public void PunOpenPoseUpdate(Vector3[] PoseList, PhotonMessageInfo info)
    {
        UpdateFlag = true;
        for (int i = 0; i <= 17; i++)
        {
            PersonPose[i] = PoseList[i];
        }
    }
}
//float NoseX, float NoseY, float NoseZ, float NeckX, float NeckY, float NeckZ, float RShoulderX, float RShoulderY, float RShoulderZ, float RElbowX, float RElbowY, float RElbowZ, float RWristX, float RWristY, float RWristZ, float LShoulderX, float LShoulderY, float LShoulderZ, float LElbowX, float LElbowY, float LElbowZ, float LWristX, float LWristY, float LWristZ, float RHipX, float RHipY, float RHipZ, float RKneeX, float RKneeY, float RKneeZ, float RAnkleX, float RAnkleY, float RAnkleZ, float LHipX, float LHipY, float LHipZ, float LKneeX, float LKneeY, float LKneeZ, float LAnkleX, float LAnkleY, float LAnkleZ, float REyeX, float REyeY, float REyeZ, float LEyeX, float LEyeY, float LEyeZ, float REarX, float REarY, float REarZ, float LEarX, float LEarY, float LEarZ
