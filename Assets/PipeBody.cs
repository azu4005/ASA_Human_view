using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBody : MonoBehaviour
{
    public GameObject Root;
    public GameObject LStem;
    public GameObject RStem;
    Vector3 RootPos;
    Vector3 LStemPos;
    Vector3 RStemPos;
    Vector3 ThisPos;
    Quaternion ThisRote;
    // Start is called before the first frame update
    void Start()
    {

        // Start is called before the first frame update
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        LStemPos = LStem.transform.position;
        RStemPos = RStem.transform.position;
        RootPos = Root.transform.position;
        ThisPos = ((LStemPos + RStemPos) / 2 + RootPos) / 2;
        this.transform.position = ThisPos;
        this.transform.up = (RStemPos + LStemPos) / 2 - ThisPos;
        //this.transform.rotation = Quaternion.LookRotation(StemPos - ThisPos,Vector3.up);
    }
}

