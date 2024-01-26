
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.RosBridgeClient;

public class ConnectionManager : MonoBehaviour
{
    public Text status_text;
    public GameObject ros_connector_object;

    void Update()
    {
        RosConnector ros_connector = ros_connector_object.GetComponent<RosConnector>();

        Text text = status_text.GetComponent<Text>();
        if (ros_connector.IsConnected.WaitOne(0))
        {
            text.text = "connected";
        }
        else
        {
            text.text = "disconnect";
        }
    }
}
