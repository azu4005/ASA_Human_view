using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminColorChange : MonoBehaviour
{
    // Start is called before the first frame update
    public Admin Admin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Admin.adminflag == 0)
        {
            GetComponent<Renderer>().material.color = Color.black;
        }
        else if (Admin.adminflag == 1)
        {

            GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
