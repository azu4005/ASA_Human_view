using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using std_msgs = RosSharp.RosBridgeClient.MessageTypes.Std;
using System.Threading;
using UnityEngine.UI;
using TMPro;

namespace RosSharp.RosBridgeClient
{
    [RequireComponent(typeof(RosConnector))]
    public class TestRosSharp : UnitySubscriber<std_msgs.String>
    {
        public TMPro.TMP_Text testText;
        private RosConnector rosConnector;        
        string subscription_id;
        string subscription2_id;
        /*
         private bool isMessageReceived;
         public Transform Subscribed;
         string publication_id;
 ;
         private readonly int SecondsTimeout = 3;
         */
        string talk ;
        private bool isMessageReceived;
        List<string> meg = new List<string>();

        // Start is called before the first frame update
         /*void Start()
         {
             testText = GetComponent<TextMeshProUGUI>();
             rosConnector = GetComponent<RosConnector>();
             Debug.Log("Established connection with ros");

             if (!rosConnector.IsConnected.WaitOne(SecondsTimeout * 1000))
                 Debug.LogWarning("Failed to subscribe: RosConnector not connected");


             publication_id = rosConnector.RosSocket.Advertise<std_msgs.String>("publication_test");

             subscription_id = rosConnector.RosSocket.Subscribe<std_msgs.String>("/subscription_test", SubscriptionHandler);

             subscription2_id = rosConnector.RosSocket.Subscribe<std_msgs.String>("/chatter", SubscriptionHandler2);



         }*/
        protected override void Start()
        {

            //base.Start();
            GameObject text = GameObject.Find("Textbox");
            testText = text.GetComponent<TextMeshPro>();
            rosConnector = GetComponent<RosConnector>();
            subscription_id = rosConnector.RosSocket.Subscribe<std_msgs.String>("/subscription_test", ReceiveMessage);

            subscription2_id = rosConnector.RosSocket.Subscribe<std_msgs.String>("/chatter", SubscriptionHandler2);
            
        }


        protected override void ReceiveMessage(std_msgs.String message)
        {
           
            Debug.Log(message.data);
            talk = message.data;

            //testText.text = message.data;

            
            isMessageReceived = true;
        }

        private void  Update()
        {
            if (isMessageReceived)
                ProcessMessage();

        }
        private void ProcessMessage()
        {
            testText.text = talk;
            isMessageReceived = false;
        }

        private static string SubscriptionHandler(std_msgs.String message)
        {
           
            
           //testText.SetText(message.data);
            Debug.Log(message.data);                    //print ROS's message to unity

            return message.data;
        }
        private static void SubscriptionHandler2(std_msgs.String message)
        {
            
            Debug.Log(message.data);                    //print ROS's message to unity
        }
    }
}
