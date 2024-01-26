using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using custom_tutorials_msgs = RosSharp.RosBridgeClient.MessageTypes.CustomTutorials;


namespace RosSharp.RosBridgeClient
{
    [RequireComponent(typeof(RosConnector))]

    public class CustomSub : UnitySubscriber<custom_tutorials_msgs.CustomMessage>
    {
        private bool isMessageReceived;
        private RosConnector rosConnector;
        string t;
        int v;
        string subscription_id;

       
        protected override void Start()
        {

           base.Start();
            
           rosConnector = GetComponent<RosConnector>();
           //subscription_id = rosConnector.RosSocket.Subscribe<cus_msgs.Custom>("/talker", ReceiveMessage);

        }
        protected override void ReceiveMessage(custom_tutorials_msgs.CustomMessage message)
        {

            Debug.Log("receved message");
            t = message.word;
            v = message.number;
            //testText.text = message.data;


            isMessageReceived = true;
        }

        // Update is called once per frame
        private void Update()
        {
            if (isMessageReceived)
                ProcessMessage();

        }
        private void ProcessMessage()
        {
            Debug.Log(t);
            Debug.Log(v);
        }
        private static void SubscriptionHandler(custom_tutorials_msgs.CustomMessage message)
        {


            //testText.SetText(message.data);
            Debug.Log(message.word);                    //print ROS's message to unity
            Debug.Log(message.number);
            
        }

    }
}