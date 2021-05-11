using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

class ConfigData
{
    /// <summary>
    /// 激活次数
    /// </summary>
    public int Times;

}


public class Config : MonoBehaviour
{
    public static Config Instance;

    private ConfigData configData  = new ConfigData();

    private string File_name = "config.txt";
    private string Path;

    private void Awake()
    {
        Instance = this;
        Path = Application.streamingAssetsPath + "/" + File_name;

        if (FileHandle.Instance.IsExistFile(Path))
        {
            string st = FileHandle.Instance.FileToString(Path);
            configData = JsonConvert.DeserializeObject<ConfigData>(st);
        }
        else
        {
            InitData();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LogMsg.Instance.Log("Times=="+ configData.Times);
    }

    private void OnDestroy()
    {



    }

    private void InitData()
    {
        configData.Times = 0;
    }

    public void SaveData()
    {
        string st = JsonConvert.SerializeObject(configData);
        FileHandle.Instance.SaveFile(st, Path);
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }
}
