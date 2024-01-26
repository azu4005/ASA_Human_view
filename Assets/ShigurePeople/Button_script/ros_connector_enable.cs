using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RosSharp.RosBridgeClient;

public class ros_connector_enable : MonoBehaviour
{
    [SerializeField] private GameObject ros_connector;
    [SerializeField] private GameObject console_controller;
    [SerializeField] private GameObject ip_controller;
    [SerializeField] private GameObject publish_controller;
    [SerializeField] private GameObject subscribe_controller;
    [SerializeField] private GameObject tf_transform_controller;
    [SerializeField] private GameObject depth_controller;

    private int click_count = 1;
    private int click_pose_count = 1;
    private int click_contacted_count = 1;

    private RosConnector ros_connector_script;
    private ShigurePeopleSubscriber ros_shigure_people_script;
    private ShigureContactSubscriber ros_shigure_contacted_script;
    private HoloLensTf2Publisher ros_hololens_tf2_script;
    private AnchorTf2Publisher ros_anchor_tf2_script;
    private Tf2Subscriber ros_tf2_convert_script;

    Vector3 PeoplePos;
    // Start is called before the first frame update
    void Start()
    {

        ros_connector_script = ros_connector.GetComponent<RosConnector>();
        ros_shigure_people_script = ros_connector.GetComponent<ShigurePeopleSubscriber>();
        ros_shigure_contacted_script = ros_connector.GetComponent<ShigureContactSubscriber>();
        ros_hololens_tf2_script = ros_connector.GetComponent<HoloLensTf2Publisher>();
        ros_anchor_tf2_script = ros_connector.GetComponent<AnchorTf2Publisher>();
        ros_tf2_convert_script = ros_connector.GetComponent<Tf2Subscriber>();

        publish_controller.SetActive(false);
        subscribe_controller.SetActive(false);
        tf_transform_controller.SetActive(false);
        depth_controller.SetActive(false);
    }

    // Update is called once per frame
    void Update() { }

    public void onClick_ROSConnect()
    {
        // ON(初回クリック) : ROSコネクタを有効
        // ON : ROSコネクタを再度有効
        // OFF : ROSコネクタを無効
        if (click_count == 1)
        {
            ros_connector.SetActive(true);

            console_controller.SetActive(true);
            ip_controller.SetActive(false);
            publish_controller.SetActive(true);
            subscribe_controller.SetActive(true);
        } else if (click_count % 2 == 1)
        {
            ros_connector_script.Awake();
            ros_connector.SetActive(true);
            console_controller.SetActive(true);
            ip_controller.SetActive(false);
            publish_controller.SetActive(true);
            subscribe_controller.SetActive(true);
        } else
        {
            ros_connector_script.OnClickQuit();
            ros_connector.SetActive(false);
            console_controller.SetActive(false);
            ip_controller.SetActive(true);
            publish_controller.SetActive(false);
            subscribe_controller.SetActive(false);
        }

        click_count++;
        Debug.Log("cl_main" + click_count);
    }

    public void onClick_Tf2Active()
    {
        ros_hololens_tf2_script.enabled = true;
        ros_anchor_tf2_script.enabled = true;

        ros_tf2_convert_script.enabled = true;

        publish_controller.SetActive(false);
        tf_transform_controller.SetActive(true);

    }

    public void onClick_Tf2TransformActive()
    {
        tf_transform_controller.SetActive(false);
        depth_controller.SetActive(true);

    }

    // ON : Subscriberを有効
    // OFF : ROSコネクタを一時無効(Subscriberを解除), かつROSコネクタを再度有効に
    public void onClick_PoseActive()
    {
        if (click_pose_count % 2 == 1)
        {
            ros_shigure_people_script.OnClickStart();
        } else {
            ros_connector_script.OnClickQuit();
            Invoke("UnsubscribeMessage", 2.0f);
        }

        click_pose_count++;
        Debug.Log("cl_pose" + click_pose_count);
    }

    // ON : Subscriberを有効
    // OFF : ROSコネクタを一時無効(Subscriberを解除), かつROSコネクタを再度有効に
    public void onClick_ContactedActive()
    {
        if (click_contacted_count % 2 == 1)
        {
            ros_shigure_contacted_script.OnClickStart();
        } else {
            ros_connector_script.OnClickQuit();
            Invoke("UnsubscribeMessage", 2.0f);
        }

        click_contacted_count++;
        Debug.Log("cl_con" + click_contacted_count);
    }

    private void UnsubscribeMessage()
    {
        Debug.Log("ROS Connectorを再度有効にしました。");
        ros_connector_script.Awake();
    }

    public void onClick_Plusx() 
    {
        // tf_move.gameObject.transform.parent = null;
        PeoplePos = GameObject.Find("Peoples").transform.position;
        PeoplePos.x += 0.1f;
        GameObject.Find("Peoples").transform.position = PeoplePos;
        Debug.Log("xに10cm");
    }
    public void onClick_Plusy()
    {
        // tf_move.gameObject.transform.parent = null;
        PeoplePos = GameObject.Find("Peoples").transform.position;
        PeoplePos.y += 0.1f;
        GameObject.Find("Peoples").transform.position = PeoplePos;
        Debug.Log("yに10cm");
    }
    public void onClick_Plusz()
    {
        // tf_move.gameObject.transform.parent = null;
        PeoplePos = GameObject.Find("Peoples").transform.position;
        PeoplePos.z += 0.1f;
        GameObject.Find("Peoples").transform.position = PeoplePos;
        Debug.Log("zに10cm");
    }


    public void onClick_Minusx()
    {
        //  tf_move.gameObject.transform.parent = null;
        PeoplePos = GameObject.Find("Peoples").transform.position;
        PeoplePos.x -= 0.1f;
        GameObject.Find("Peoples").transform.position = PeoplePos;
        Debug.Log("xに-10cm");
    }
    public void onClick_Minusy()
    {
        //  tf_move.gameObject.transform.parent = null;
        PeoplePos = GameObject.Find("Peoples").transform.position;
        PeoplePos.y -= 0.1f;
        GameObject.Find("Peoples").transform.position = PeoplePos;
        Debug.Log("yに-10cm");
    }
    public void onClick_Minusz()
    {

        //  tf_move.gameObject.transform.parent = null;
        PeoplePos = GameObject.Find("Peoples").transform.position;
        PeoplePos.z -= 0.1f;
        GameObject.Find("Peoples").transform.position = PeoplePos;
        Debug.Log("zに-10cm");
    }



}
