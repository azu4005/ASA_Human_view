using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeLShin : MonoBehaviour
{
    public GameObject LShinRoot;
    public GameObject LShinStem;
    Vector3 LShinRootPos;
    Vector3 LShinStemPos;
    Vector3 ThisPos;
    Quaternion ThisRote;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LShinStemPos = LShinStem.transform.position;
        LShinRootPos = LShinRoot.transform.position;
        ThisPos = (LShinStemPos + LShinRootPos) / 2;
        this.transform.position = ThisPos;
        this.transform.up = LShinStemPos - ThisPos;
        //this.transform.rotation = Quaternion.LookRotation(LShinStemPos - ThisPos,Vector3.up);
    }
}
