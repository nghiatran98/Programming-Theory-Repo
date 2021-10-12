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
        DisplayScore();
        DisplayHighScore();
    }

    void DisplayScore()
    {
        scoreText.text = "Score: " + gameManager.score;
    }

    void DisplayHighScore()
    {
        highScoreText.text = "High Score: " + MainManager.Instance.bestPlayerName + ": " + MainManager.Instance.highScore;
    }
}
