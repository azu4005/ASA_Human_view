using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public GameObject Root;
    public GameObject Stem;
    Vector3 RootPos;
    Vector3 StemPos;
    Vector3 ThisPos;
    Quaternion ThisRote;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StemPos = Stem.transform.position;
        RootPos = Root.transform.position;
        ThisPos = (StemPos + RootPos) / 2;
        this.transform.position = ThisPos;
        this.transform.up = StemPos - ThisPos;
        //this.transform.rotation = Quaternion.LookRotation(StemPos - ThisPos,Vector3.up);
    }
}
