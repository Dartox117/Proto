using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clous : MonoBehaviour
{
    private float CloudSpeed;
    // Start is called before the first frame update
    void Start()
    {
       CloudSpeed = Random.Range(-1,-5);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(CloudSpeed*Time.deltaTime,0,0);
    }
}
