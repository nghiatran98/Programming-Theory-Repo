using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }

    public string playerName { get; private set; }
    public float highScore { get; private set; }
    public string bestPlayerName { get; private set; }


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // ABSTRACTION
    public void SavePlayerName(string name)
    {
        playerName = name;
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayerName;
        public float highScore;
    }

    // ABSTRACTION
    public void SaveHighScore(string playerName, float score)
    {
        if (score > highScore)
        {
            SaveData data = new SaveData();
            data.bestPlayerName = playerName;
            data.highScore = score;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }

    // ABSTRACTION
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            bestPlayerName = data.bestPlayerName;
        }
    }

}
