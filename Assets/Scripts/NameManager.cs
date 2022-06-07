using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class NameManager : MonoBehaviour
{
    public static NameManager Instance;
    public string playerName;
    public string highScorePlayerName;
    public int highScore;

    // Start is called before the first frame update
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string highScorePlayerName;
        public int highScore;
    }

    public void SaveRecordData() 
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.highScorePlayerName = highScorePlayerName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadRecordData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScorePlayerName = data.highScorePlayerName;
        }
    }
}
