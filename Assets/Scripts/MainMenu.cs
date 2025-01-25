using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject menuCredits;
    public AudioSource CLickSound;
    public void Play()
    {
        CLickSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Credits()
    {
        CLickSound.Play();
        mainMenu.SetActive(false);
        menuCredits.SetActive(true);
    }
    public void Menu()
    {   CLickSound.Play();
        menuCredits.SetActive(false);
        mainMenu.SetActive(true);
    }

}
