using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLVL1 : MonoBehaviour
{
    public HealthBar healthBar;
    public ProtoMoove protoMoove;
    [SerializeField] AudioSource Sound;

    private void OnTriggerEnter2D (Collider2D player)
    {
        healthBar.FreezeSpeed = 0.00025f;
        protoMoove.ActualDamage = protoMoove.Damage;
        Sound.volume = 0.8f;
     
    }

}
