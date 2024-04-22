using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene("SCN_TUTO");
    }

    public void QuitButton()
    { 
        Application.Quit();
    }

    public void OptionsButton()
    {
       SceneManager.LoadScene("SCN_Options");
    }
}
