using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);

        // Store Player Name to Main Manager
        MainManager.Instance.StorePlayerName(nameInput.text);
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
