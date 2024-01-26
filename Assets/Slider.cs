using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    private int flag;
    public static int Shareflag;
    public static Vector3 GetPos;
    public GameObject NowTimeText;
    float SendZ;
    Vector3 Max;
    Vector3 Min;
    Quaternion thisRote;
    public static Vector3 thispos;
    Vector3 prethispos;
    // Start is called before the first frame update
    void Start()
    {
        
        /*
        Parent = GameObject.Find("ParentAnchor");
        this.transform.parent = Parent.transform;
        */
        flag = 0;
        //Max‚ÉPosSet.cs‚Ìpos‚Æ“¯‚¶À•W‚ð“ü‚ê‚éB
        Max.x = 0.5f;
        Max.y = 0.5f;
        Max.z = 0.0f;
        Min.x = -Max.x;
        Min.y = Max.y;
        Min.z = Max.z;
        //NowTimeText = GameObject.Find("NowTimeText");
        thispos = Vector3.zero;
        thispos.x = Max.x;
        thispos.y = Max.y;
        thispos.z = Max.z;
        this.transform.position = thispos;
        //plane1 = GameObject.Find("Plane (1)");
        thisRote = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        flag++;
        prethispos = this.transform.localPosition;
        //Debug.Log(this.transform.localPosition);
        thispos.x = prethispos.x;
        if (thispos.x > Max.x)
        {
            thispos.x = Max.x;
        }
        else if (thispos.x < Min.x)
        {
            thispos.x = Min.x;
        }
        if (flag % 1 == 0)
        {
            SendZ = (Max.x +0.5f - (thispos.x + 0.5f)) * 2f;
            //Debug.Log(DBsubscriber.pinchslider);
            DBsubscriber.pinchslider = SendZ;
            //OpenPoseSet.getslider = SendZ;
            //Debug.Log(SendZ);
            if (thispos.x == Max.x)
            {
                NowTimeText.GetComponent<TextMesh>().text = ("SelectTime||" + DBsubscriber.nt.hour.ToString() + ":" + DBsubscriber.nt.min.ToString() + ":" + DBsubscriber.nt.sec.ToString() + "(Start Time)");
            }
            else if (thispos.x == Min.x)
            {
                NowTimeText.GetComponent<TextMesh>().text = ("SelectTime||" + DBsubscriber.nt.hour.ToString() + ":" + DBsubscriber.nt.min.ToString() + ":" + DBsubscriber.nt.sec.ToString() + "(End Time)");
            }
            else
            {
                NowTimeText.GetComponent<TextMesh>().text = ("SelectTime||" + DBsubscriber.nt.hour.ToString() + ":" + DBsubscriber.nt.min.ToString() + ":" + DBsubscriber.nt.sec.ToString());
            }


            if(Shareflag == 1 && Admin.adminflag == 0)
            {
                thispos = GetPos;
                this.transform.localPosition = thispos;
            }
            else if (Shareflag == 0)
            {
                this.transform.localPosition = thispos;
            }
            else
            {
                
            }
            Shareflag = 0;
        }

        this.transform.rotation = thisRote;
    }
}
