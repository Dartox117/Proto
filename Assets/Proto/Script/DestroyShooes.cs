using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShooes : MonoBehaviour
{
    [SerializeField] ProtoMoove ProtoMoove;
    public GameObject self;
    [SerializeField] GameObject Texte;
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
        ProtoMoove.DestroyActive = true;
        Texte.SetActive(true);
        self.SetActive(false);
    }
}

