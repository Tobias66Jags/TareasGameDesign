using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonClassSample : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public string jsonString;
    public string fileName = "save.info";

    private void Awake()
    {
        LoadPlayerInfo();
    }

    private void Start()
    {
        
    }

    [ContextMenu("Print Player Info")]
   public void PrintPlayerInfo()
    {
        Debug.Log(JsonUtility.ToJson(playerInfo, true));    
    }
    [ContextMenu("Load Player Info")]
    public void LoadPlayerInfo()
    {
       //playerInfo =  JsonUtility.FromJson<PlayerInfo>(jsonString);   
       string path = Path.Combine(Application.persistentDataPath, fileName);
        playerInfo = JsonUtility.FromJson<PlayerInfo>(File.ReadAllText(path)); 
    }

    public void SavePlayerInfo(Vector3 playerPosition,Quaternion playerRotation, bool hasWeapon )
    {
        playerInfo.sceneInfo.position = playerPosition;
        playerInfo.sceneInfo.rotation = playerRotation;
        playerInfo.hasWeapon = hasWeapon;

        File.WriteAllText(Path.Combine(Application.persistentDataPath, fileName), JsonUtility.ToJson(playerInfo)); 
    }
}

[System.Serializable]

public class PlayerInfo
{
    public string Name; 
    public string Level;
    public string Health;
    public bool hasWeapon;
    public SceneInfo sceneInfo;
}

[System.Serializable]

public class SceneInfo
{
    public Vector3 position;
    public Quaternion rotation; 
}
