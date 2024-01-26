using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient;
using Microsoft.MixedReality.Toolkit.UI;
using RosSharp.RosBridgeClient.MessageTypes.DetectObject;

/*ORderverから情報を受け取り，オブジェクト設置*/

public class DBsubscriber : MonoBehaviour
{
    private RosSocket rosSocket;
    public int UpdateTime = 0;
    //受け取ったトピックを格納する配列
    //[0]は初めに持ち込まれた物体の情報,[1]は次に持ち込まれた物体の情報,[2]はその次に...
    public int[] FrameB;  //モニタリングシステムが稼働してから物体が持ち込まれるまでのFrame数(使ってない)
    public int[] FrameT;  //MSが稼働してから物体が持ち去られるまでのFrame数(使ってない)
    public int[] TimeB;  //物体が持ち込まれた時刻
    public int[] TimeT;  //物体が持ち去られた時刻(持ち去られていない場合は0が返ってくる)
    public int[] id;  //持ち込まれた順に付与される番号(使ってない)
    public int[] Xmin;  //以下その物体の（画像の）座標とサイズ
    public int[] Ymin;
    public int[] Width;
    public int[] Height;
    public int[] Depth;
    public int[] Yobi; //トピックの内容(メッセージ)を書き換えるのは手間がかかるので緊急時の為の変数(何も格納されてない)
    public int[] YobiYobi;

    public int cnt;  //物体の個数
    //public int one;

    public int MinTime;  //最初にイベントが起こった時刻
    public int MaxTime;  //最後にイベントが起こった時刻
    public int MinSec;   //MS稼働から最初にイベントが起こるまでの時間(秒)
    public int MaxSec;   //MS稼働から最後にイベントが起こるまでの時間(秒)
    public int[] BSec;   //MS稼働から物体が持ち込まれるまでの時間(秒)
    public int[] TSec;   //MS稼働から物体が持ち去られるまでの時間(秒)

    public float nowtime;
    public struct NowTime //今の時刻
    {
        public int hour;
        public int min;
        public int sec;
    }

    public struct BeginTime //左端の時刻
    {
        public int hour;
        public int min;
        public int sec;
    }
    public struct EndTime //右端の時刻
    {
        public int hour;
        public int min;
        public int sec;
    }

    BeginTime bt = new BeginTime { hour = 0, min = 0, sec = 0 };
    EndTime et = new EndTime { hour = 0, min = 0, sec = 0 };
    public static NowTime nt = new NowTime { hour = 0, min = 0, sec = 0 };

    public GameObject Plane0; //各オブジェクトを貼るPlane
    public GameObject Plane1;
    public GameObject Plane2;
    public GameObject Plane3;
    public GameObject Plane4;
    public GameObject Plane5;
    public GameObject[] Plane;

    public GameObject texttimeobject;
    TextMesh texttime;
    public float Slidery;
    //public GameObject PinchSliders;
    public static float pinchslider;

    //MoveTimeBar movetime;
    public bool movecomp;

    IDdecision iddecision;
    GameObject WorldEditorID;
    private int holoid;
    private string idstr;
    public bool num_check_topic = false;

    void Start()
    {
        //Debug.Log("Start_start");

        BSec = new int[20];
        TSec = new int[20];
        //Debug.Log("Start_start1");

        Plane = new GameObject[6];  //物体の画像が貼られるPlane
        Plane[0] = Plane0;
        Plane[1] = Plane1;
        Plane[2] = Plane2;
        Plane[3] = Plane3;
        Plane[4] = Plane4;
        Plane[5] = Plane5;

        //Debug.Log("Start_start2");

        nowtime = 0;

        texttime = texttimeobject.GetComponent<TextMesh>();

        //Debug.Log("Start_start3");

        WorldEditorID = GameObject.Find("WorldEditor");
        iddecision = WorldEditorID.GetComponent<IDdecision>();

        holoid = iddecision.ids;
        idstr = holoid.ToString("0");
        /*cnt = 0;
        //微調整用テストコードここから
        FrameB = new int[3];
        FrameT = new int[3];
        TimeB = new int[3];
        TimeT = new int[3];
        id = new int[3];
        Xmin = new int[3];
        Ymin = new int[3];
        Height = new int[3];
        Width = new int[3];
        Depth = new int[3];
        Yobi = new int[3];
        YobiYobi = new int[3];
        
        FrameB[0] = 0;
        FrameT[0] = 0;
        TimeB[0] = 0;
        TimeT[0] = 0;
        id[0] = 0;
        Xmin[0] = 256;
        Ymin[0] = 204;
        Width[0] = 8;
        Height[0] = 24;
        Depth[0] = 1769;
        Yobi[0] = 0;
        YobiYobi[0] = 0;

        FrameB[1] = 0;
        FrameT[1] = 0;
        TimeB[1] = 0;
        TimeT[1] = 0;
        id[1] = 1;
        Xmin[1] = 239;
        Ymin[1] = 214;
        Width[1] = 34;
        Height[1] = 21;
        Depth[1] = 1678;
        Yobi[1] = 0;
        YobiYobi[1] = 0;

        FrameB[2] = 0;
        FrameT[2] = 0;
        TimeB[2] = 0;
        TimeT[2] = 0;
        id[2] = 2;
        Xmin[2] = 218;
        Ymin[2] = 155;
        Width[2] = 56;
        Height[2] = 81;
        Depth[2] = 1587;
        Yobi[2] = 0;
        YobiYobi[2] = 0;
        
        */
        //covid
        /*
        FrameB[0] = 1;
        FrameT[0] = 0;
        TimeB[0] = 1;
        TimeT[0] = 0;
        id[0] = 0;
        Xmin[0] = 232;
        Ymin[0] = 203;
        Width[0] = 7;
        Height[0] = 23;
        Depth[0] = 1787;
        Yobi[0] = 0;
        YobiYobi[0] = 0;

        FrameB[1] = 1;
        FrameT[1] = 0;
        TimeB[1] = 0;
        TimeT[1] = 0;
        id[1] = 1;
        Xmin[1] = 245;
        Ymin[1] = 215;
        Width[1] = 28;
        Height[1] = 20;
        Depth[1] = 1689;
        Yobi[1] = 0;
        YobiYobi[1] = 0;

        FrameB[2] = 1;
        FrameT[2] = 0;
        TimeB[2] = 0;
        TimeT[2] = 0;
        id[2] = 2;
        Xmin[2] = 218;
        Ymin[2] = 155;
        Width[2] = 56;
        Height[2] = 81;
        Depth[2] = 1587;
        Yobi[2] = 0;
        YobiYobi[2] = 0;
        cnt = 3;
        */
        //微調整用テストコードここまで
        Debug.Log("Start_finish");
        Invoke("Init", 1.0f);
    }

    public void Init()
    {
        Debug.Log("Init_Start");
        rosSocket = GetComponent<RosConnector>().RosSocket;
        //Topicを受け取ったら関数NuｍResが呼び出される
        //rosSocket.Subscribe<DBinfo>("/shelfDB_" + idstr, NumRes , UpdateTime);
        rosSocket.Subscribe<DBinfo>("/shelfDB", NumRes, UpdateTime);
        Debug.Log("Init_Finish");
        //rosSocket.Subscribe("/shelfDB_" + idstr, "detect_object/DBinfo", NumRes, UpdateTime);
    }

    void NumRes(DBinfo message) //受け取った情報を格納
    {
        Debug.Log("NumRes_Start");
        DBinfo datas = (DBinfo)message;
        Debug.Log("NumRes_Start2");
        FrameB = datas.FrameB;
        FrameT = datas.FrameT;
        TimeB = datas.TimeB;
        TimeT = datas.TimeT;
        id = datas.id;
        Xmin = datas.Xmin;
        Ymin = datas.Ymin;
        Width = datas.Width;
        Height = datas.Height;
        Depth = datas.Depth;
        Yobi = datas.Yobi;
        YobiYobi = datas.YobiYobi;
        cnt = datas.cnt;

        MaxTime = 0;
        MinTime = 0;
        
        num_check_topic = true;

        Debug.Log("NumRes_Finish");

    }

    //物体の持ち去り時間を０時０分０秒からの秒数に変換する
    //02時10分05秒は021005という数字で送られてきて管理しづらいので
    public int ChangeTime(int time)
    {
        int ctime;
        int hour;
        int min;
        int sec;
        hour = time / 10000;
        min = time / 100 - (hour * 100);
        sec = time - (hour * 10000) - (min * 100);

        ctime = hour * 3600 + min * 60 + sec;

        return ctime;
    }


    void Update()
    {
        //ORサーバからのtopicを受け取ったら
        if (num_check_topic)
        {
            PlaneChange();
        }
        //最初と最後のイベント時刻を秒数に変換。30+-はなくてもよい。見やすくするため
        MaxSec = ChangeTime(MaxTime) + 30;    //30秒+-
        MinSec = ChangeTime(MinTime) - 30;


        Slidery = pinchslider;
        //Debug.Log("update");
        nowtime = MinSec + (MaxSec - MinSec) * (Slidery / 2f);
        Slidery = Slidery * (MaxSec - MinSec) / 2f;  //??
        //TimeTextにバーの位置が指し示す時刻を表示する
        nt.hour = (int)nowtime / 3600;
        nt.min = ((int)nowtime % 3600) / 60;
        nt.sec = ((int)nowtime % 3600) % 60;
        //texttime.text = "Time|| " + nt.hour.ToString() + ":" + nt.min.ToString() + ":" + nt.sec.ToString();

        //バーの位置が指し示す時刻に存在しなかった物体(の画像を貼ったPlane)を非表示にする
        for (int i = 0; i < cnt; i++) //i=0は一つ目の物体についての処理 i=1は二つ目の物体についての処理 i=2は三つ目の...
        {
            BSec[i] = ChangeTime(TimeB[i]);  //bring時の時間
            TSec[i] = ChangeTime(TimeT[i]);  //take時の時間

            //takeされなかった物体のTsec(持ち去られた時刻)は0なのでMaxSecを格納
            if (TSec[i] == 0)
            {
                TSec[i] = MaxSec;
            }

            //持ち込まれた時刻より後に、バーの位置が指し示す時刻がある。&&持ち去られた時刻より前にバーの位置が指し示す時刻がある。場合に物体表示
            if ((BSec[i] - MinSec) <= Slidery && Slidery <= (TSec[i] - MinSec))
            {
                Plane[i].SetActive(true);
            }
            else
            {
                Plane[i].SetActive(false);
            }
        }

    }
    public void OnSliderUpdated(SliderEventData eventData)
    {
        pinchslider = 2 * (eventData.NewValue);

    }
    void PlaneChange()
    {
        Debug.Log("change");
        for (int i = 0; i < cnt; i++)  //i=0は一つ目の物体についての処理 i=1は二つ目の物体についての処理 i=2は三つ目の...
        {
            //物体の情報をPleneに反映 書き直し必須
            Plane[i].transform.localScale = new Vector3(Width[i] * 0.001f, 0.1f, Height[i] * 0.001f);
            Plane[i].transform.localPosition = new Vector3((Xmin[i] * 0.01f) + (Width[i] * 0.005f) - 2.46f, (Ymin[i] * 0.01f * -1) + 1.65f - (Height[i] * 0.005f), 1f + Depth[i] * 0.00001f);
            /*
            Plane[i].transform.localScale = new Vector3(Width[i] * 0.0006f, 0.1f, Height[i] * 0.0006f);
            Plane[i].transform.localPosition = new Vector3((Xmin[i] * 0.01f) + (Width[i] * 0.005f) - 2.9f, (Ymin[i] * 0.01f * -1) + 1.59f - (Height[i] * 0.005f),1.7f + Depth[i] * 0.00001f);
            */
            //Debug.Log(Plane[i].transform.localScale);
            //最後のイベント時刻を知る
            MinTime = TimeB[0]; //Beginning is bringed first objects
            MaxTime = TimeB[i];
            if (MaxTime < TimeT[i])
            {
                MaxTime = TimeT[i];
            }
        }
        bt.hour = MinTime / 10000;
        bt.min = (MinTime / 100) - (bt.hour * 100);
        bt.sec = MinTime - (bt.hour * 10000) - (bt.min * 100);

        et.hour = MaxTime / 10000;
        et.min = (MaxTime / 100) - (et.hour * 100);
        et.sec = MaxTime - (et.hour * 10000) - (et.min * 100);
        num_check_topic = false;

    }

}
