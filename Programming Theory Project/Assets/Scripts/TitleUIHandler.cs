using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleUIHandler : MonoBehaviour
{
    // Encapsulation of variables and methods
    [SerializeField] private GameObject warningText;
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private bool isNameInputEmpty;
    // Start is called before the first frame update
    void Start()
    {
        DisplayHighScore();
    }

    public void StartNew()
    {
        checkPlayerName();
        LoadMainScene();
    }

    public void Exit()
    {
        EditorApplication.ExitPlaymode();

        Application.Quit();
    }

    void checkEmptyName()
    {
        isNameInputEmpty = string.IsNullOrEmpty(nameInput.text);

        if (isNameInputEmpty)
        {
            warningText.SetActive(true);
        }
        else
        {
            warningText.SetActive(false);
        }
    }

    void checkPlayerName()
    {
        checkEmptyName();

        if (isNameInputEmpty)
        {
            return;
        }
        else
        {
            // Save Player Name
            MainManager.Instance.SavePlayerName(nameInput.text);
        }
    }

    void LoadMainScene()
    {
        // Switch to the main scene only when the user has entered their name
        if (isNameInputEmpty)
        {
            return;
        }

        else
        {
            SceneManager.LoadScene(1);
        }
        
    }

    void DisplayHighScore()
    {
        MainManager.Instance.LoadHighScore();
        highScoreText.text = "High Score: " + MainManager.Instance.bestPlayerName + ": " + MainManager.Instance.highScore;
    }

}
