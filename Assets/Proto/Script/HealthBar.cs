using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image Bar;
    [SerializeField] ProtoMoove protoMoove;
    public float FreezeSpeed;
    public float ActualFreezeSpeed=0.0001f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        healthBar();
        Frozen();
    }

    private void healthBar()
    {
        Bar.fillAmount += FreezeSpeed;
    }

    private void Frozen()
    {
        if (Bar.fillAmount >= 1) 
        {
            protoMoove.Death();
        }
    }

}
