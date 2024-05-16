using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMenu : MonoBehaviour
{
    [SerializeField] ProtoMoove protomoove;
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
        Time.timeScale = 1.0f;
    }
    public void RespawnDefeat()
    {
        protomoove.Respawn();
    }
}
