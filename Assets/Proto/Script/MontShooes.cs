using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontShooes : MonoBehaviour
{
    [SerializeField] ProtoMoove ProtoMoove;
    public GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D Player)
    {
        ProtoMoove.MontActive = true;
        self.SetActive(false);
    }
}
