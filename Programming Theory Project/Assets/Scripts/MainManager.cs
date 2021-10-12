using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    // Encapsulate public class "MainManager" and public variable "playerName"
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

    public void SavePlayerName(string name)
    {
        playerName = name;
    }

    public void SetHighScore(string playerName, float score)
    {
        if (score > highScore)
        {
            highScore = score;
            bestPlayerName = playerName;
        }
    }

}
