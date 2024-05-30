// Unity 
using UnityEngine;

[System.Serializable]
public struct OrientationByAngle
{
    public float link1;
    public float link2;
    public float link3;
    public float link4;
    public float link5;
    public float link6;
}
public class RobotControl : MonoBehaviour
{
    public OrientationByAngle orientation = new();
    private RobotManager RM;
    private UniversalRobot robot;

    

    void Start()
    {
        RM = RobotManager.Instance;
        robot = RM.Robot;

        orientation.link1 = robot.J_Orientation[0] * Mathf.Rad2Deg;
        orientation.link2 = robot.J_Orientation[1] * Mathf.Rad2Deg;
        orientation.link3 = robot.J_Orientation[2] * Mathf.Rad2Deg;
        orientation.link4 = robot.J_Orientation[3] * Mathf.Rad2Deg;
        orientation.link5 = robot.J_Orientation[4] * Mathf.Rad2Deg;
        orientation.link6 = robot.J_Orientation[5] * Mathf.Rad2Deg;

    }

    void Update()
    {
        robot.J_Orientation[0] = orientation.link1 * Mathf.Deg2Rad;
        robot.J_Orientation[1] = orientation.link2 * Mathf.Deg2Rad;
        robot.J_Orientation[2] = orientation.link3 * Mathf.Deg2Rad;
        robot.J_Orientation[3] = orientation.link4 * Mathf.Deg2Rad;
        robot.J_Orientation[4] = orientation.link5 * Mathf.Deg2Rad;
        robot.J_Orientation[5] = orientation.link6 * Mathf.Deg2Rad;
    }
}
