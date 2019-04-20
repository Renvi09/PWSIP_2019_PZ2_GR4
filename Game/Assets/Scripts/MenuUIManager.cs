using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("Intro");
    }

    public void Options()
    {
        SceneManager.LoadScene("");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
