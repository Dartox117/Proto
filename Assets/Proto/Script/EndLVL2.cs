using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLVL2 : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;
    [SerializeField] GameObject Snow;
    [SerializeField] AudioSource Sound;

    private void OnTriggerEnter2D(Collider2D player)
    {
        healthBar.FreezeSpeed = 0.00045f;
        Sound.volume = 1f;
        Snow.SetActive(false);
    }

}
