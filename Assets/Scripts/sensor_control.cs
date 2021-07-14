using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Robotics.ROSTCPConnector;

public class sensor_control : MonoBehaviour
{
    ROSConnection ros;
    public string topicName;
    public Rigidbody sensor;
    // Start is called before the first frame update
    void Start()
    {
        ros = ROSConnection.instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RosMessageTypes.WinchController.MDepth current_depth = new RosMessageTypes.WinchController.MDepth();
        current_depth.depth = sensor.transform.position[1];
        ros.Send(topicName, current_depth);
    }
}
