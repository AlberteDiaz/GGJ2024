using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        Debug.Log("UWU");
        SceneManager.LoadScene("CharacterSelection");
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public void MenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Menu");
    }

    public void CreditosButton()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void ExitButton()
    {
        Application.Quit(0);
    }

    public void InstruccionesButton()
    {
        SceneManager.LoadScene("Instrucciones");
    }
}
