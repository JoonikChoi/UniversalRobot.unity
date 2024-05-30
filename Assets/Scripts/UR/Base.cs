/*****************************************************************************
Author   : Joonik Choi (lighthouse)
Email    : omybell201@gmail.com / lighthouse@portal301.com
Github   : https://github.com/
File Name: link1.cs
****************************************************************************/
// Unity 
using UnityEngine;

public class Base : MonoBehaviour
{    
    void Awake()
    {
        var ResourceDirectoryPath = Application.dataPath + "/Resources/UR/UR5e/" + "arm_0_si30_vpn.glb";
        var gltf = gameObject.AddComponent<GLTFast.GltfAsset>();
        gltf.Url = ResourceDirectoryPath;   
    }

    void OnApplicationQuit()
    {
        Destroy(this);
    }
}
