using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class niseSlider : MonoBehaviour
{
    public GameObject slider;

    Vector3 thispos;
    Vector3 Max;
    Vector3 Min;
    // Start is called before the first frame update
    void Start()
    {
        //slider = GameObject.Find("Cube");
        Max.x = 0.5f;
        Max.y = 0.5f;
        Max.z = 0.0f;
        Min.x = -Max.x;
        Min.y = Max.y;
        Min.z = Max.z;
    }

    // Update is called once per frame
    void Update()
    {
        thispos = slider.transform.localPosition;
        if (thispos.x > Max.x)
        {
            thispos.x = Max.x;
        }
        else if (thispos.x < Min.x)
        {
            thispos.x = Min.x;
        }
        this.transform.localPosition = thispos;
    }
}
