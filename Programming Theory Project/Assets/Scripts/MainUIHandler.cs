using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class MainUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private GameManager gameManager;
    private string playerName;
    
    // Start is called before the first frame update
    void Start()
    {
        playerName = MainManager.Instance.playerName;
        playerNameText.SetText(playerName);

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // ABSTRACTION
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // ABSTRACTION
    public void GoToStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    // ABSTRACTION
    public void Exit()
    {
        EditorApplication.ExitPlaymode();

        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScore();
        DisplayHighScore();
    }

    // ABSTRACTION
    void DisplayScore()
    {
        scoreText.text = "Score: " + gameManager.score;
    }

    // ABSTRACTION
    void DisplayHighScore()
    {
        MainManager.Instance.LoadHighScore();
        highScoreText.text = "High Score: " + MainManager.Instance.bestPlayerName + ": " + MainManager.Instance.highScore;
    }
}
