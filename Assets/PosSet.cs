using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosSet : MonoBehaviour
{
    public GameObject Parent;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject Parent;
        //Parent = GameObject.Find("ParentAnchor");
        this.transform.parent = Parent.transform;
        Vector3 pos;
        pos.x = 0f;
        pos.y = 2f;
        pos.z = -15f;
        this.transform.localPosition = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
