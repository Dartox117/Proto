using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] AudioSource Click;
    // Start is called before the first frame update
    void Start()
    {
        Click.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void QuitOptionsButton()
    {
        SceneManager.LoadScene("SCN_TITLESCREEN");
    }
}

