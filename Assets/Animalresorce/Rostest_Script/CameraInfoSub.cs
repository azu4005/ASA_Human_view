using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace RosSharp.RosBridgeClient
{
    [RequireComponent(typeof(RosConnector))]
    public class CameraInfoSub : UnitySubscriber<MessageTypes.Tf2.TFMessage>
    {
        private bool isMessageReceived ;
        private RosConnector rosConnector;
        public Dictionary<string, Transform> tfs;
        public Transform camera1;
        public Transform Hololens2_1;
        private Quaternion _q;
        private Vector3 _v;
        private string _name;

        private Vector3 position;
        private Quaternion rotation;
        protected override void Start()
        {
            base.Start();
            rosConnector = GetComponent<RosConnector>();
            tfs = new Dictionary<string, Transform>();
            tfs.Add("room_camera1", camera1);
            tfs.Add("Hololens2_1", Hololens2_1);


        

        }

        private void Update()
        {
            if (isMessageReceived)
                ProcessMessage();
        }


        protected override void ReceiveMessage(MessageTypes.Tf2.TFMessage message)
        {

            isMessageReceived = true;
            if (tfs.ContainsKey(message.transforms[0].child_frame_id))
            {
                _v = new Vector3((float)message.transforms[0].transform.translation.x,
                    (float)message.transforms[0].transform.translation.y,
                    (float)message.transforms[0].transform.translation.z);
                _q = new Quaternion((float)message.transforms[0].transform.rotation.x,
                    (float)message.transforms[0].transform.rotation.y,
                    (float)message.transforms[0].transform.rotation.z,
                    (float)message.transforms[0].transform.rotation.w);
                _name = message.transforms[0].child_frame_id;
            }
        }



        private void ProcessMessage()
        {
            tfs[_name].localPosition = _v.Ros2Unity();
            tfs[_name].localRotation = _q.Ros2Unity();
            //tfs[_name].localPosition = _v;
            //tfs[_name].localRotation = _q;

            
            isMessageReceived = false;

        }

    }
}