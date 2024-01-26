using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.UI;
using System;
using UnityEngine.Events;

public class CreateBird : MonoBehaviour
{

    private bool isActive;
    public GameObject Bird;

    void Start()
    {
        isActive = false;
    }
    // Start is called before the first frame update
    public void CreatingBard(GameObject theObject)
    {

        if (isActive == false)
        {
            isActive = !isActive;
            theObject.SetActive(isActive);
            Debug.Log("Bird appeared");
            Debug.Log(this.transform.parent.InverseTransformPoint(theObject.transform.position));

        }
        else
        {
            isActive = false;
            theObject.SetActive(isActive);
            Debug.Log("Bird disappeared");
        }
            
      
    }


}
