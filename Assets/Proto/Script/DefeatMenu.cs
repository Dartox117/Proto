using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class DefeatMenu : MonoBehaviour
{
    [SerializeField] GameObject RespawnButton;
    [SerializeField] GameObject ResumeButton;
    [SerializeField] HealthBar healthBar;
    public bool CanPause;
    public bool CanDie;
    [SerializeField] ProtoMoove protomoove;
    public void DefeatMainMenu()
    {
        SceneManager.LoadScene("SCN_TITLESCREEN");
        Time.timeScale = 1.0f;
    }
    public void RespawnDefeat()
    {
        CanPause = true;
        StartCoroutine(protomoove.Respawn());
        healthBar.CanDie = true;

    }
    public IEnumerator ResumeGame()
    {
        Time.timeScale = 1.0f;
        protomoove.PauseMenu.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        if (protomoove.IsIntro == false)
        {
            healthBar.FreezeSpeed = healthBar.ActualFreezeSpeed;
            protomoove.CanMoove = true;
            
        }
        
    }

    public void Pause()
    {

        if (Input.GetButtonDown("Pause"))
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(ResumeButton);
            healthBar.FreezeSpeed = 0f;
            protomoove.CanMoove = false;
            Time.timeScale = 0.0f;
            protomoove.PauseMenu.SetActive(true);
        }
    }
    public void Death()
    {
        protomoove.CanMoove = false;
        Time.timeScale = 0f;
        CanPause = false;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(RespawnButton);
        protomoove.DefeatMenu.SetActive(true);
            
        

    }
    public void Resume()
    {
        StartCoroutine(ResumeGame());
    }
}
