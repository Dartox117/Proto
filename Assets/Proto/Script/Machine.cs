using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Machine : MonoBehaviour
{
    private float Ypos;
    private float Xpos;

    private void Start()
    {
        
    }
    void  Update()
    {
        Xpos = Random.Range(940.50f, 940.7f);
        Ypos = Random.Range(9.5f, 9.55f);
        transform.position = new Vector3(Xpos,Ypos,-10f) ;
    }
}
