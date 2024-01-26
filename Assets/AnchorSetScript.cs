using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorSetScript : MonoBehaviour
{
    int Frame;
    int Flag;
    public GameObject ImageParent;
    public GameObject Anchor;
    public GameObject Child;
    Vector3 preset;
    Vector3 preset2;
    // Start is called before the first frame update
    void Start()
    {
        Flag = 0;
        //ImageParent = GameObject.Find("ImageParents");
        //Anchor = GameObject.Find("ParentAnchor");
        //Child = GameObject.Find("PUNCHILDOBJECT");
        preset2.x = 2f;
        preset2.y = 0.0f;
        preset2.z = -2.0f;
        Child.transform.position = preset2;
        ImageParent.transform.parent = Child.transform;
        Child.transform.parent = Anchor.transform;
        preset.x = -2f;
        preset.y = -3f;
        preset.z = 1f;
        Anchor.transform.position = Vector3.zero;
        Child.transform.rotation = Quaternion.AngleAxis(-90,transform.up);
    }

    // Update is called once per frame
    void Update()
    {
        Frame++;
        if(Frame%60 == 0)
        {
            //ImageParent.transform.localPosition = preset;
            //Debug.Log(Child.transform.position);
        }
    }
}
