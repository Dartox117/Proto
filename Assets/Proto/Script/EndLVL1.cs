using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLVL1 : MonoBehaviour
{
    [SerializeField] GameObject Snow;
    [SerializeField] GameObject Snow2;
    [SerializeField] GameObject Snow3;

    private void OnTriggerEnter2D(Collider2D Player)
    {
        Snow.SetActive(false);
        Snow2.SetActive(false);
        Snow3.SetActive(true);
    }

}
