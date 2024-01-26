/* 
 * This message is auto generated by ROS#. Please DO NOT modify.
 * Note:
 * - Comments from the original code will be written in their own line 
 * - Variable sized arrays will be initialized to array of size 0 
 * Please report any issues at 
 * <https://github.com/siemens/ros-sharp> 
 */



namespace RosSharp.RosBridgeClient.MessageTypes.ShigureCoreRos1
{
    public class Cube : Message
    {
        public const string RosMessageName = "shigure_core_ros1_msgs/Cube";

        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float width { get; set; }
        public float height { get; set; }
        public float depth { get; set; }

        public Cube()
        {
            this.x = 0.0f;
            this.y = 0.0f;
            this.z = 0.0f;
            this.width = 0.0f;
            this.height = 0.0f;
            this.depth = 0.0f;
        }

        public Cube(float x, float y, float z, float width, float height, float depth)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.width = width;
            this.height = height;
            this.depth = depth;
        }
    }
}
