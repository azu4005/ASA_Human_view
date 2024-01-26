using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidPlaneResize : MonoBehaviour
{
    public GameObject Cube;
    Vector3 ThisPos;
    Vector3 ThisScale;
    float slider;
    // Start is called before the first frame update
    void Start()
    {
        //Cube = GameObject.Find("Cube");
        ThisPos = this.transform.localPosition;
        ThisScale = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        slider = DBsubscriber.pinchslider;
        ThisPos.x = (slider - 2f) / -4f;
        this.transform.localPosition = ThisPos;
        ThisScale.x = slider / 20;
        this.transform.localScale = ThisScale;
    }
}
