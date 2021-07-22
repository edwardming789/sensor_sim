using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.WinchController;

public class sensor_control : MonoBehaviour
{
    ROSConnection ros;
    public string topicName;
    public Rigidbody sensor;
    public bool is_stop = true;
    private float target_vel;
    // Start is called before the first frame update
    void Start()
    {
        ros = ROSConnection.instance;
        ros.Subscribe<MCommand>("simulator/command",command_callback);
        //sensor.isKinematic = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RosMessageTypes.WinchController.MDepth current_depth = new RosMessageTypes.WinchController.MDepth();
        current_depth.depth = -sensor.transform.position[1];
        ros.Send(topicName, current_depth);

        if(is_stop)
        {
            sensor.isKinematic = true;
            //sensor.AddForce(new Vector3(0,2.9068f,0));
        }
        else
        {
            sensor.isKinematic = false;
        }
            
    }
    //  MSetVelocityResponse set_vel_callback(MSetVelocityRequest req)
    // {
    //     target_vel = req.vel;
    //     Debug.Log(target_vel);
    //     sensor.velocity = new Vector3(0,target_vel,0);
    //     if(target_vel == 0)
    //         is_stop = true;
    //     else
    //         is_stop = false;
    //     return new MSetVelocityResponse(true);
    // }

    void command_callback(MCommand msg)
    {
        target_vel = msg.vel;
        //Debug.Log(msg);
        sensor.velocity = new Vector3(0,target_vel,0);
        if(target_vel == 0)
            is_stop = true;
        else
            is_stop = false;
    }
}
