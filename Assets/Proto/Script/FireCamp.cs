using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCamp : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        healthBar.FreezeSpeed = -0.003f;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        healthBar.FreezeSpeed = healthBar.ActualFreezeSpeed;
    }



}
