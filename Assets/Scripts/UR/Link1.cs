/*****************************************************************************
Author   : Joonik Choi (lighthouse)
Email    : omybell201@gmail.com / lighthouse@portal301.com
Github   : https://github.com/
File Name: link1.cs
****************************************************************************/

// System
using System;
using GLTFast.Schema;

// Unity 
using UnityEngine;
using UnityEngine.SceneManagement;

public class Link1 : MonoBehaviour
{
    private RobotManager RM;
    private UniversalRobot robot;
    
    void Awake()
    {
        var ResourceDirectoryPath = Application.dataPath + "/Resources/UR/UR5e/" + "arm_1_si30_vpn.glb";
        var gltf = gameObject.AddComponent<GLTFast.GltfAsset>();
        gltf.Url = ResourceDirectoryPath;   
    }


    void Start()
    {
        RM = RobotManager.Instance;
        robot = RM.Robot;
        transform.localPosition = robot.LinkPosition[0]; // ex. Arm1 -> 0 init position allocated.        
    }

    void FixedUpdate()
    {
        try
        {
            float J_Orientation = 0.0f;
            J_Orientation = robot.J_Orientation[0];

            transform.localRotation = Quaternion.Euler(new Vector3(0.0f, -(float)(J_Orientation * Mathf.Rad2Deg), 0.0f));


        }
        catch (Exception e)
        {
            Debug.Log("Exception:" + e);
        }
    }
    void OnApplicationQuit()
    {
        Destroy(this);
    }
}
