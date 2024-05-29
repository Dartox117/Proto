using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EndCinematiqueTrigger : MonoBehaviour
{
    [SerializeField] PlayableDirector End;
    [SerializeField] ProtoMoove protomoove;
    [SerializeField] GameObject VictoryMenu;
    [SerializeField] DefeatMenu defeatMenu;
    [SerializeField] GameObject MainMenuButton;
    [SerializeField] Chrono chrono;
    [SerializeField] AudioSource Sound;
    private void OnTriggerEnter2D(Collider2D Player)
    {
        Sound.volume = 0.3f;
        protomoove.ActualStep.Stop();
        protomoove.CanMoove = false;
        chrono.timePaused = true;
        End.Play();
    }

    public void EndGame()
    {
        protomoove.ActualStepSound.Stop();
        VictoryMenu.SetActive(true);
        chrono.DisplayTime(chrono.timeValue);
        defeatMenu.CanPause = false;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(MainMenuButton);
        protomoove.CanMoove = false;
        Time.timeScale = 0f;
    }
}
