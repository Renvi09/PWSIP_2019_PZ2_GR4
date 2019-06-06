using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    public AudioSource scare;

    public void Play()
    {
        SceneManager.LoadScene("Intro");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ToMenu()
    {
        StartCoroutine(licznik());
    }

    IEnumerator licznik()
    {
        scare.volume = 1;
        scare.Play();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Menu");
    }
}
