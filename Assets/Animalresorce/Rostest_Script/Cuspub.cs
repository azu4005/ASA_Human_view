using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RosSharp.RosBridgeClient
{
    public class Cuspub : UnityPublisher<MessageTypes.CustomLecture.Custom>
    {

        protected override void Start()
        {
            RosConnector ros_connector = GetComponent<RosConnector>();
            ros_connector.IsConnected.WaitOne(ros_connector.SecondsTimeout * 1000);
            base.Start();
        }

        private void FixedUpdate()
        {
            MessageTypes.CustomLecture.Custom message;
            message = new MessageTypes.CustomLecture.Custom();
            message.word = "custom msg";
            message.number = 42;
            Publish(message);
        }
    }
}

