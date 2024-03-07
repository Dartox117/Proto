using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigg3 : MonoBehaviour
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
    private void OnTriggerStay2D(Collider2D other)
    {
        cameraA.Priority = 100;
        cameraB.Priority = 1;
        cameraC.Priority = 1;
    }
}
