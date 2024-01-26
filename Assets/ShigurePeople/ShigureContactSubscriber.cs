using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RosSharp.RosBridgeClient;

public class ShigureContactSubscriber : UnitySubscriber<RosSharp.RosBridgeClient.MessageTypes.ShigureCoreRos1.ContactedList>
{
    private bool receivedMsg = false;

    private TrackingObjectCube object_cude_list;

    // 描画オブジェクト
    private GameObject bounding3d;
    private GameObject bounding3d_line;

    private float px;
    private float py;
    private float pz;
    private float width_size;
    private float height_size;
    private float depth_size;
    private string action = "neutral";
    float alpha_Sin;
    float zpos;
    int actionCount;
    protected override void Start() 
    {
        CreateBoundingBox();

        bounding3d = GameObject.Find("BoundingBox3D");
        var bounding_renderer = bounding3d.AddComponent<Renderer>();
        bounding3d.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        bounding3d.transform.SetParent(GameObject.Find("tf_move").transform);
        var scale = bounding3d.transform.localScale;

        scale.x = 0;
        scale.y = 0;
        scale.z = 0;
        bounding3d.transform.localScale = scale;

        actionCount = 1;

    }

    public void OnClickStart()
    {
        base.Start();
    }

    protected override void ReceiveMessage(RosSharp.RosBridgeClient.MessageTypes.ShigureCoreRos1.ContactedList message)
    {
        receivedMsg = true;
        
        
        var contacted_list_num = 0;
/*
        Debug.Log("x : " + message.contacted_list[0].object_cube.x);
        Debug.Log("y : " + message.contacted_list[0].object_cube.y);
        Debug.Log("z : " + message.contacted_list[0].object_cube.z);
        Debug.Log("wi : " + message.contacted_list[0].object_cube.width);
        Debug.Log("he : " + message.contacted_list[0].object_cube.height);
        Debug.Log("de : " + message.contacted_list[0].object_cube.depth);
        Debug.Log("length : " + message.contacted_list.Length);
*/
        px = message.contacted_list[contacted_list_num].object_cube.x;
        py = message.contacted_list[contacted_list_num].object_cube.y;
        pz = message.contacted_list[contacted_list_num].object_cube.z;
        width_size = message.contacted_list[contacted_list_num].object_cube.width;
        height_size = message.contacted_list[contacted_list_num].object_cube.height;
        depth_size = message.contacted_list[contacted_list_num].object_cube.depth;
        action = message.contacted_list[contacted_list_num].action;

        Debug.Log("action : " + action);

     /* Debug.Log("x : " + px);
        Debug.Log("y : " + py);
        Debug.Log("z : " + pz);
        Debug.Log("wi : " + width_size);
        Debug.Log("he : " + height_size);
        Debug.Log("de : " + depth_size);
     */
    }


    private void CreateBoundingBoxLine(GameObject prefab_line, string create_line_name, float px, float py, float pz, float qx, float qy, float qz)
    {
        var create_line = Instantiate(prefab_line, Vector3.zero, Quaternion.identity);
        create_line.name = create_line_name;
        create_line.transform.SetParent(GameObject.Find("BoundingBox3D").transform);

        var pos = create_line.transform.position;
        pos.x += px;
        pos.y += py;
        pos.z += pz;

        create_line.transform.position = pos;
        create_line.transform.rotation = Quaternion.Euler(qx, qy, qz);
    }
  /* private void CubeBoundingBox()
    {
        if (bounding3d == null)
        {
            bounding3d = new GameObject("BoundingBox3D");
        }
        bounding3d_line = GameObject.CreatePrimitive(PrimitiveType.Cube);
        bounding3d_line.transform.localScale = new Vector3(0.1f, 0.003f, 0.003f);
        bounding3d_line.name = "bounding_box_cube";



    }*/

        private void CreateBoundingBox()
    {
        if (bounding3d == null)
        {
            bounding3d = new GameObject("BoundingBox3D");
        }

        bounding3d_line = GameObject.CreatePrimitive(PrimitiveType.Cube);
        bounding3d_line.transform.localScale = new Vector3(0.1f, 0.003f, 0.003f);
        bounding3d_line.name = "bounding_box_line";

        // Bottom
        CreateBoundingBoxLine(bounding3d_line, "bottom_front", 0f, -0.05f, -0.05f, 0f, 0f, 0f);
        CreateBoundingBoxLine(bounding3d_line, "bottom_left", -0.05f, -0.05f, 0f, 0f, 90f, 0f);
        CreateBoundingBoxLine(bounding3d_line, "bottom_right", 0.05f, -0.05f, 0f, 0f, 90f, 0f);
        CreateBoundingBoxLine(bounding3d_line, "bottom_behind", 0f, -0.05f, 0.05f, 0f, 0f, 0f);

        // Top
        CreateBoundingBoxLine(bounding3d_line, "top_front", 0f, 0.05f, -0.05f, 0f, 0f, 0f);
        CreateBoundingBoxLine(bounding3d_line, "top_left", -0.05f, 0.05f, 0f, 0f, 90f, 0f);
        CreateBoundingBoxLine(bounding3d_line, "top_right", 0.05f, 0.05f, 0f, 0f, 90f, 0f);
        CreateBoundingBoxLine(bounding3d_line, "top_behind", 0f, 0.05f, 0.05f, 0f, 0f, 0f);

        // Side
        CreateBoundingBoxLine(bounding3d_line, "side_front_l", -0.05f, 0f, -0.05f, 0f, 0f, 90f);
        CreateBoundingBoxLine(bounding3d_line, "side_front_r", 0.05f, 0f, -0.05f, 0f, 0f, 90f);
        CreateBoundingBoxLine(bounding3d_line, "side_behind_l", -0.05f, 0f, 0.05f, 0f, 0f, 90f);
        CreateBoundingBoxLine(bounding3d_line, "side_behind_r", 0.05f, 0f, 0.05f, 0f, 0f, 90f);

        bounding3d_line.SetActive(false);
    }

    private void TransformBoundingBox(float px, float py, float pz, float width_size, float height_size, float depth_size)
    {
        bounding3d = GameObject.Find("BoundingBox3D");

        // BoundingBox3Dが生成済みの場合
        if (bounding3d != null)
        {
            bounding3d.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            var pos = bounding3d.transform.localPosition;
            pos.x =  (px / 1000) + 0.037f;
            pos.y = (-py / 1000) - 0.226f;
            pos.z = (pz / 1000) + 0.161f;

            bounding3d.transform.localPosition = pos;

            var scale = bounding3d.transform.localScale;

            scale.x = width_size / 100;
            scale.y = height_size / 100;
            scale.z = (pz - depth_size) / 400;
            bounding3d.transform.localScale = scale;
            zpos = pos.z;
        }
    }


    private void Colorflashing()
    {
        alpha_Sin = Mathf.Sin(Time.time) / 2 + 0.5f;
        //   Color _color = bounding3d_line.GetComponent<Color>();
       

        foreach (Transform child in bounding3d.transform)
        {
            GameObject childObject = child.gameObject;
            var _color2 = childObject.GetComponent<Renderer>().material.color;
            childObject.GetComponent<Renderer>().material.color = new Color(255,0,0, alpha_Sin);
       //     childObject.GetComponent<Renderer>().material.color = _color2;

        }


    }

    private void DeleateBoundingBox()
    {
        var scale = bounding3d.transform.localScale;
        scale.x = 0;
        scale.y = 0;
        scale.z = 0;
        bounding3d.transform.localScale = scale;
    }

    public void Update() 
    {
        if (action == "neutral")
        {

        }
        else if (action == "touch")
        {
            if ((zpos + 1.0f ) > pz && (zpos - 1.0f) < pz) 
            {
                TransformBoundingBox(px, py, pz, width_size, height_size, depth_size);
                Colorflashing();
            }

            if (actionCount == 1)
            {
                TransformBoundingBox(px, py, pz, width_size, height_size, depth_size);
            }
            Colorflashing();
        //    Debug.Log("Object status : touch");
            action = "stay";
            // TODO : 色変更 -> https://qiita.com/OKsaiyowa/items/f995ad9c0884fb2ced8f
        }
        else if (action == "bring_in")
        {
            TransformBoundingBox(px, py, pz, width_size, height_size, depth_size);
            action = "stay";
          //  Debug.Log("Object status : bring_in");
        }
        else if (action == "stay")
        {
            foreach (Transform child in bounding3d.transform)
            {
                GameObject childObject = child.gameObject;
                var _color2 = childObject.GetComponent<Renderer>().material.color;
                childObject.GetComponent<Renderer>().material.color = Color.white;
                _color2.a = alpha_Sin;
                //     childObject.GetComponent<Renderer>().material.color = _color2;

            }
           // Debug.Log("Object status : Stay");
        }
        else if (action == "take_out")
        {
            Invoke(nameof(DeleateBoundingBox),3.0f);
            actionCount = 0;
           // Debug.Log("Object status : take_out");
        }
        else
        {
            action = "neutral";

            foreach (Transform child in bounding3d.transform)
            {
                GameObject childObject = child.gameObject;
                var _color2 = childObject.GetComponent<Renderer>().material.color;
                childObject.GetComponent<Renderer>().material.color = Color.white;
                _color2.a = alpha_Sin;
                //     childObject.GetComponent<Renderer>().material.color = _color2;

            }
        }
        actionCount++;
    }
}
