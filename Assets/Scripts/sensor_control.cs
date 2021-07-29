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
    private Vector3 target_vel;
    // Start is called before the first frame update
    void Start()
    {
        ros = ROSConnection.instance;
        //ros.Subscribe<MCommand>("simulator/command",command_callback);
        ros.ImplementService<MWinchTriggerRequest>("winch/winch_up", winch_up_callback);
        ros.ImplementService<MWinchTriggerRequest>("winch/winch_down", winch_down_callback);
        ros.ImplementService<MWinchTriggerRequest>("winch/winch_stop", winch_stop_callback);
        //sensor.isKinematic = true;
    }

    MWinchTriggerResponse winch_up_callback(MWinchTriggerRequest req)
    {
        target_vel = new Vector3(0,0.3302f,0);
        is_stop = false;
        MWinchTriggerResponse res = new MWinchTriggerResponse();
        res.result = true;
        return res;
    }

    MWinchTriggerResponse winch_down_callback(MWinchTriggerRequest req)
    {
        target_vel = new Vector3(0,-0.3566f,0);
        is_stop = false;
        MWinchTriggerResponse res = new MWinchTriggerResponse();
        res.result = true;
        return res;
    }

    MWinchTriggerResponse winch_stop_callback(MWinchTriggerRequest req)
    {
        target_vel = new Vector3(0,0,0);
        is_stop = true;
        MWinchTriggerResponse res = new MWinchTriggerResponse();
        res.result = true;
        return res;
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
            sensor.velocity = target_vel;
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

    // void command_callback(MCommand msg)
    // {
    //     target_vel = msg.vel;
    //     //Debug.Log(msg);
    //     sensor.velocity = new Vector3(0,target_vel,0);
    //     if(target_vel == 0)
    //         is_stop = true;
    //     else
    //         is_stop = false;
    // }
}
