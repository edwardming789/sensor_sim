//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.WinchController
{
    public class MSetVelocityResponse : Message
    {
        public const string RosMessageName = "winch_controller/SetVelocity";

        public bool complete;

        public MSetVelocityResponse()
        {
            this.complete = false;
        }

        public MSetVelocityResponse(bool complete)
        {
            this.complete = complete;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.Add(BitConverter.GetBytes(this.complete));

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            this.complete = BitConverter.ToBoolean(data, offset);
            offset += 1;

            return offset;
        }

        public override string ToString()
        {
            return "MSetVelocityResponse: " +
            "\ncomplete: " + complete.ToString();
        }
    }
}