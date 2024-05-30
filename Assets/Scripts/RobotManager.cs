using System.IO;
using UnityEngine;

public class RobotManager : MonoBehaviour
{
    private static RobotManager _instance;

    // 외부에서 인스턴스에 접근할 때 사용할 프로퍼티

    public static RobotManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<RobotManager>();
                if (_instance == null)
                {
                    GameObject manager = new GameObject("@RobotManagers");
                    _instance = manager.AddComponent<RobotManager>();
                }
            }
            return _instance;
        }
    }


    private UniversalRobot _Robot = new(UR.Robot.ModelName.UR5e);

    public UniversalRobot Robot
    {
        get
        {
            return _Robot;
        }
    }

    private void Awake() // This function is called when the object becomes enabled and active ... edit by Joonik
    {
        Application.runInBackground = true;
        Debug.Log("hello");

        // Ensure there is only one instance of GameManager
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
