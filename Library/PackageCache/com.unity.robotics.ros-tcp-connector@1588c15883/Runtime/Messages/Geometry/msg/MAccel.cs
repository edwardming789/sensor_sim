//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Geometry
{
    public class MAccel : Message
    {
        public const string RosMessageName = "geometry_msgs/Accel";

        //  This expresses acceleration in free space broken into its linear and angular parts.
        public MVector3 linear;
        public MVector3 angular;

        public MAccel()
        {
            this.linear = new MVector3();
            this.angular = new MVector3();
        }

        public MAccel(MVector3 linear, MVector3 angular)
        {
            this.linear = linear;
            this.angular = angular;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.AddRange(linear.SerializationStatements());
            listOfSerializations.AddRange(angular.SerializationStatements());

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            offset = this.linear.Deserialize(data, offset);
            offset = this.angular.Deserialize(data, offset);

            return offset;
        }

        public override string ToString()
        {
            return "MAccel: " +
            "\nlinear: " + linear.ToString() +
            "\nangular: " + angular.ToString();
        }
    }
}
