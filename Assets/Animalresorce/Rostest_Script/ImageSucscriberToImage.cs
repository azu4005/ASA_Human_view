using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RosSharp.RosBridgeClient
{
    public class ImageSucscriberToImage : UnitySubscriber<MessageTypes.Sensor.CompressedImage>
    {
        public GameObject image_object;

        private Texture2D texture2D;
        private byte[] imageData;
        private bool isMessageReceived;

        protected override void Start()
        {
            base.Start();
            texture2D = new Texture2D(1, 1);
        }
        private void Update()
        {
            if (isMessageReceived)
                ProcessMessage();
        }

        protected override void ReceiveMessage(MessageTypes.Sensor.CompressedImage compressedImage)
        {
            imageData = compressedImage.data;
            isMessageReceived = true;
        }

        private void ProcessMessage()
        {
            texture2D.LoadImage(imageData);
            texture2D.Apply();
            isMessageReceived = false;

            Image image_component = image_object.GetComponent<Image>();
            image_component.sprite = Sprite.Create(texture2D,
                                                   new Rect(0, 0, texture2D.width, texture2D.height),
                                                   Vector2.zero);
        }
    }
}

