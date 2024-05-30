/****************************************************************************
MIT License
Copyright(c) 2021 Roman Parak
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*****************************************************************************
Author   : Roman Parak
Email    : Roman.Parak @outlook.com
Github   : https://github.com/rparak
File Name: ur3_link1.cs
****************************************************************************/

// System
using System;
using GLTFast.Schema;

// Unity 
using UnityEngine;
using UnityEngine.SceneManagement;

public class Link4 : MonoBehaviour
{
    private RobotManager RM;
    private UniversalRobot robot;
    
    void Awake()
    {
        var ResourceDirectoryPath = Application.dataPath + "/Resources/UR/UR5e/" + "arm_4_si30_vpn.glb";
        var gltf = gameObject.AddComponent<GLTFast.GltfAsset>();
        gltf.Url = ResourceDirectoryPath;
    }


    void Start()
    {
        RM = RobotManager.Instance;
        robot = RM.Robot;
        transform.localPosition = robot.LinkPosition[3]; // ex. Arm1 -> 0 init position allocated.        
    }

    void FixedUpdate()
    {
        try
        {
            float J_Orientation = 0.0f;
            J_Orientation = robot.J_Orientation[3];

            transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, (float)(J_Orientation * Mathf.Rad2Deg)));


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
