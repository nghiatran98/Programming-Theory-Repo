using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class MainUIHandler : MonoBehaviour
{

    private string playerName;
    public TextMeshProUGUI playerNameText;

    // Start is called before the first frame update
    void Start()
    {
        playerName = MainManager.Instance.playerName;
        playerNameText.SetText(playerName);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        EditorApplication.ExitPlaymode();

        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
