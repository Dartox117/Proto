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
    private void OnTriggerEnter2D(Collider2D Player)
    {
        protomoove.ActualStep.Stop();
        protomoove.CanMoove = false;
        chrono.timePaused = true;
        End.Play();
    }

    public void EndGame()
    {
        VictoryMenu.SetActive(true);
        chrono.DisplayTime(chrono.timeValue);
        defeatMenu.CanPause = false;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(MainMenuButton);
        protomoove.CanMoove = false;
        Time.timeScale = 0f;
    }
}
