using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTuto : MonoBehaviour
{
    [SerializeField] ProtoMoove proto;
    private void OnTriggerEnter2D(Collider2D player)
    {
        proto.IsTuto = false;
    }

}
