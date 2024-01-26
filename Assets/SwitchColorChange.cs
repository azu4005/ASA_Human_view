using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchColorChange : MonoBehaviour
{
    public ShareSwitch ShareSwitch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ShareSwitch.Share == 0)
        {

            GetComponent<Renderer>().material.color = Color.black;
        }
        else if(ShareSwitch.Share == 1)
        {

            GetComponent<Renderer>().material.color = Color.green;

        }
    }
}
