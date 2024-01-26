/*
© Siemens AG, 2017-2018
Author: Dr. Martin Bischoff (martin.bischoff@siemens.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

// Added allocation free alternatives
// UoK , 2019, Odysseas Doumas (od79@kent.ac.uk / odydoum@gmail.com)

using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class PoseStampedPublisher : UnityPublisher<MessageTypes.Geometry.PoseStamped>
    {
        public Transform RealsenceTransform;
        public string FrameId = "Hololens2";
        Vector3 pos;
        Vector3 dirforward;
        Vector3 dirup;
        GameObject targetObject;
        private MessageTypes.Geometry.PoseStamped message;

        protected override void Start()
        {
            targetObject = Camera.main.gameObject;
            
            base.Start();
            InitializeMessage();
        }

        private void FixedUpdate()
        {
            pos= RealsenceTransform.InverseTransformPoint(targetObject.transform.position);
            dirforward = RealsenceTransform.InverseTransformDirection(targetObject.transform.forward);
            dirup = RealsenceTransform.InverseTransformDirection(targetObject.transform.up);
            UpdateMessage(pos, dirforward, dirup);
        }

        private void InitializeMessage()
        {
            message = new MessageTypes.Geometry.PoseStamped
            {
                header = new MessageTypes.Std.Header()
                {
                    frame_id = FrameId
                }
            };
        }

        private void UpdateMessage(Vector3 pos, Vector3 dirforward, Vector3 dirup)
        {
            this.transform.forward = RealsenceTransform.TransformDirection(dirforward);
            dirforward = this.transform.forward;
            this.transform.up = RealsenceTransform.TransformDirection(dirup);
            dirup = this.transform.up;
            this.transform.rotation = Quaternion.LookRotation(dirforward, dirup);
            message.header.Update();
            GetGeometryPoint(pos.Unity2Ros(), message.pose.position);
            GetGeometryQuaternion(this.transform.rotation.Unity2Ros(), message.pose.orientation);

            Publish(message);
        }

        private static void GetGeometryPoint(Vector3 position, MessageTypes.Geometry.Point geometryPoint)
        {
            geometryPoint.x = position.x;
            geometryPoint.y = position.y;
            geometryPoint.z = position.z;
        }

        private static void GetGeometryQuaternion(Quaternion quaternion, MessageTypes.Geometry.Quaternion geometryQuaternion)
        {
            geometryQuaternion.x = quaternion.x;
            geometryQuaternion.y = quaternion.y;
            geometryQuaternion.z = quaternion.z;
            geometryQuaternion.w = quaternion.w;
        }

    }
}
