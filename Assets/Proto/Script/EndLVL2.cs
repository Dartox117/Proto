using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLVL2 : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;
    [SerializeField] GameObject Snow;

    private void OnTriggerEnter2D(Collider2D player)
    {
        healthBar.FreezeSpeed = 0.0005f;
        Snow.SetActive(false);
    }

}
