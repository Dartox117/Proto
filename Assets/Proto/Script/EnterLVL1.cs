using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLVL1 : MonoBehaviour
{
    public HealthBar healthBar;
    public ProtoMoove protoMoove;

    private void OnTriggerEnter2D (Collider2D player)
    {
        healthBar.FreezeSpeed = 0.00025f;
        protoMoove.ActualDamage = protoMoove.Damage;
     
    }

}
