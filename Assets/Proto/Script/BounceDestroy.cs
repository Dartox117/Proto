using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceDestroy : MonoBehaviour
{
    public GameObject Plat;
    [SerializeField] ProtoMoove Chauss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Chauss.Shooes == 4)
            {
                Debug.Log("Destruction");
                Plat.SetActive(false);
            }
        }

    }
}
