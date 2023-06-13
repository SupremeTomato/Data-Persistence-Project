using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveName : MonoBehaviour
{
    public static SaveName Instance;

    public string playerName;
    public string bestPlayer;
    public int bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPlayerName();
    }

    [System.Serializable]
    class SaveData
        {
            public string playerName;
            public int bestScore;
            public string bestPlayer;
        }

    public void SavePlayerName()
    {

        SaveData data = new SaveData();
        data.playerName = playerName;
        data.bestPlayer = bestPlayer;
        data.bestScore = bestScore;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }
    public void LoadPlayerName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            bestPlayer = data.bestPlayer;
            bestScore = data.bestScore;
        }
    }
    


}
