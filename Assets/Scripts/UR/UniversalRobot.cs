using UnityEngine;
using System.Collections.Generic;

namespace UR.Robot
{
    public enum ModelName
    {
        UR5e = 0,
    }
}

[System.Serializable]
public class UR5eInit
{
    public List<Vector3> LinkPositionParams = new()
        {
                new(0, 0.0991f, 0),
                new(0, 0.0634f, -0.0744f),
                new(-0.425f, 0, 0),
                new(-0.39225f, 0, 0.0215f),
                new(0, -0.0463f, -0.0804f),
                new(0, -0.0534f, -0.0463f),
                new(0, 0, -0.0533f)
        };
}

public class UniversalRobot
{

    public UR.Robot.ModelName ModelName;
    public string IP = "192.167.0.3";
    public List<Vector3> LinkPosition = new();
    public float[] J_Orientation = { 0.750491578f, -1.692969374f, 1.832595715f, -0.767944871f, 0.002443461f, -0.002094395f }; // radian value
    // public float[] J_Orientation = { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f }; // radian value


    public UniversalRobot(UR.Robot.ModelName modelName)
    {
        this.ModelName = modelName;


        switch (this.ModelName)
        {
            case UR.Robot.ModelName.UR5e:
                UR5eInit ur5eInit = new();
                this.LinkPosition = ur5eInit.LinkPositionParams;
                break;
            // 후에 로봇 모델 추가시 코드 작성하면 됨.
            default:
                break;
        }

    }
}