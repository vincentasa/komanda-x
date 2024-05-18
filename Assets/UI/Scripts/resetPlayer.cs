using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class resetPlayer : MonoBehaviour
{
    public void ResetPlayer()
    {
        string path = Application.persistentDataPath + "/player.save";
        
        if (File.Exists(path))
            File.Delete(path);
    }
}
