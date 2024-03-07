using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigg2 : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cameraA;
    [SerializeField] CinemachineVirtualCamera cameraB;
    [SerializeField] CinemachineVirtualCamera cameraC;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        cameraA.Priority = 1;
        cameraB.Priority = 100;
        cameraC.Priority = 1;



    }
}