using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject PART1;
    [SerializeField] private GameObject PART2;
    [SerializeField] private GameObject ButtonStart;

    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void StartButton()
    {


        PART2.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ButtonStart);
        PART1.SetActive(false);
    }

    public void QuitButton()
    { 
        Application.Quit();
    }

    public void OptionsButton()
    {
       SceneManager.LoadScene("SCN_Options");
    }

    public void RealStart()
    {
        SceneManager.LoadScene("SCN_TUTO");
    }
}
