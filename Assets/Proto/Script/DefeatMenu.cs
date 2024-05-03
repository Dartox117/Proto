using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DefeatMainMenu()
    {
        SceneManager.LoadScene("SCN_TITLESCREEN");
    }
    public void RespawnDefeat()
    {
        SceneManager.LoadScene("SCN_TUTO");
    }
}
