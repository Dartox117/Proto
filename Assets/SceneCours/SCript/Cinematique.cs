using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Cinematique : MonoBehaviour
{
    [SerializeField] PlayableDirector Test;
    [SerializeField] PlayerMoovement Moove;
    [SerializeField] GameObject Trigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Test.Play();
        Moove.CanMoove = false;
        //StartCoroutine(mooveCD());
    }

    public void DestTrigger()
    {
        Trigger.SetActive(false);
    }

    /*IEnumerator mooveCD()
    {
        Test.Play();
        Moove.CanMoove = false;
        yield return new WaitForSeconds(8);
        Moove.CanMoove = true;
        Trigger.SetActive(false);
    }*/

}
