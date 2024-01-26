using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTrigger : MonoBehaviour
{

    public bool tap;
    bool tapped;
    int flag = 0;
    public GameObject anchor;
    // Start is called before the first frame update
    void Start()
    {
        tap = false;
        tapped = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(tapped == true)
        {
            flag++;
            if(flag % 10 == 0)
            {
                tap = true;
                
            }
        }
        */
    }
    public void click()
    {
        tap = true;
        tapped = true;
        //GameObject anchor = GameObject.Find("PUNCHILDOBJECT");
        //anchor.transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    public void OnFocus()
    {
        
    }


    public void OffFocus()
    {

    }
}
