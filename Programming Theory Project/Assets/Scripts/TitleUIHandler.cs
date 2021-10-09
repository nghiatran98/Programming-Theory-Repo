using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
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
