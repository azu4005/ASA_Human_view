/* 
 * This message is auto generated by ROS#. Please DO NOT modify.
 * Note:
 * - Comments from the original code will be written in their own line 
 * - Variable sized arrays will be initialized to array of size 0 
 * Please report any issues at 
 * <https://github.com/siemens/ros-sharp> 
 */



namespace RosSharp.RosBridgeClient.MessageTypes.DetectObject
{
    public class YoloRes : Message
    {
        public const string RosMessageName = "detect_object/YoloRes";

        public int num { get; set; }
        public string labels { get; set; }
        public string[] names { get; set; }
        public string scores { get; set; }
        public int[] x_offset { get; set; }
        public int[] y_offset { get; set; }
        public int[] width { get; set; }
        public int[] height { get; set; }

        public YoloRes()
        {
            this.num = 0;
            this.labels = "";
            this.names = new string[10];
            this.scores = "";
            this.x_offset = new int[10];
            this.y_offset = new int[10];
            this.width = new int[10];
            this.height = new int[10];
        }

        public YoloRes(int num, string labels, string[] names, string scores, int[] x_offset, int[] y_offset, int[] width, int[] height)
        {
            this.num = num;
            this.labels = labels;
            this.names = names;
            this.scores = scores;
            this.x_offset = x_offset;
            this.y_offset = y_offset;
            this.width = width;
            this.height = height;
        }
    }
}