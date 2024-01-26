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
    public class TestPrm : UnitySubscriber<std_msgs.Float32MultiArray>
    {
        private RosConnector rosConnector;
        float[] pra;
        float x;
        float y;
        float z;
        public GameObject TV;
        List<float> meg = new List<float>();
        private bool isMessageReceived;
        // Start is called before the first frame update

        protected override void Start()
        {

            base.Start();
            
            rosConnector = GetComponent<RosConnector>();
           

        }
        protected override void ReceiveMessage(std_msgs.Float32MultiArray message)
        {

            Debug.Log("coming messsage");
            pra = message.data;
            x = pra[0];
            y = pra[1];
            z = pra[2];


            //testText.text = message.data;


            isMessageReceived = true;
        }

        private void ProcessMessage()
        {
            Vector3 tmp = TV.transform.position;
            TV.transform.position = new Vector3(tmp.x + x, tmp.y + y, tmp.z + z);
            isMessageReceived = false;
        }


        // Update is called once per frame
        void Update()
        {

            if (isMessageReceived)
                ProcessMessage();

        }
    }
}
