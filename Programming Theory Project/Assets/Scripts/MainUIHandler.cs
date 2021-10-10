using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Inherit 2 methods StartNew() and Exit() from the parent class TitleUIHandler
public class MainUIHandler : TitleUIHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GoToStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
