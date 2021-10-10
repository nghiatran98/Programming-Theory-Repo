using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }

    private string m_playerName;
    public string playerName
    {
        get { return m_playerName; }
    }

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

    public void StorePlayerName(string name)
    {
        m_playerName = name;
        Debug.Log("Your Name Is: " + playerName);
    }

}
