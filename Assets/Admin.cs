using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;

public class Admin : MonoBehaviour
{
    public static int adminflag = 0;
    Vector3 ThisPos;
    float min = -0.1f;
    float mid = 0f;
    float max = 0.1f;
    int flag = 0;
    Quaternion ThisRote;
    public GameObject AdminText;

    // Start is called before the first frame update
    void Start()
    {
        ThisPos = this.transform.localPosition;
        ThisRote = this.transform.localRotation;
        //AdminText = GameObject.Find("AdminText");
    }

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
            if (ThisPos.x > mid || ShareSwitch.Share == 0)
            {
                ThisPos.x = max;
            }
            else if (ThisPos.x < mid)
            {
                ThisPos.x = min;
            }
        }

        if (ThisPos.x > mid)
        {
            adminflag = 0;
            AdminText.GetComponent<TextMesh>().text = ("Listner");
            AdminText.GetComponent<TextMesh>().color = Color.white;
        }
        else
        {
            adminflag = 1;
            AdminText.GetComponent<TextMesh>().text = ("Presenter");
            AdminText.GetComponent<TextMesh>().color = Color.green;
        }
        flag++;
        this.transform.localPosition = ThisPos;
        this.transform.localRotation = ThisRote;
    }
}
