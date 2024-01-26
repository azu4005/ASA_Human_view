using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRosConnecter : MonoBehaviour
{

    private bool isActive;
    public GameObject connecter;
    public GameObject TV;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }

    public void ConnectRos(GameObject theObject)
    {

        if (isActive == false)
        {
            isActive = !isActive;
            theObject.SetActive(isActive);
            TV.SetActive(isActive);
            Debug.Log("Rosconnecter Start");
           

        }
        else
        {
            TV = GameObject.Find("Tv_01");
            isActive = false;
            theObject.SetActive(isActive);
            TV.SetActive(isActive);
            Debug.Log("Rosconnecter Stop");
        }


    }
    public void CreateTV( GameObject TV)
    {

        if (isActive == false)
        {
            isActive = !isActive;
            TV.SetActive(isActive);
            Debug.Log("Rosconnecter Start");


        }
        else
        {
            isActive = false;
            TV.SetActive(isActive);
            Debug.Log("Rosconnecter Stop");
        }
    }
}
