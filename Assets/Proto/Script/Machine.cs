using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Machine : MonoBehaviour
{
    private float Ypos;
    private float Xpos;
    private bool IsActive;
    [SerializeField] ParticleSystem Snow;

    private void Start()
    {
        IsActive = true;
    }
    void  Update()
    {
        if (IsActive)
        {
            Xpos = Random.Range(940.50f, 940.7f);
            Ypos = Random.Range(9.5f, 9.55f);
            transform.position = new Vector3(Xpos, Ypos, -10f);
        }

    }
    public void EndMachine()
    {
        IsActive = false;
        Snow.Stop();
    }
}
