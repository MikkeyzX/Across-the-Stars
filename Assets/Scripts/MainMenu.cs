using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject menuCredits;
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Credits()
    {
        mainMenu.SetActive(false);
        menuCredits.SetActive(true);
    }
    public void Menu()
    {
        menuCredits.SetActive(false);
        mainMenu.SetActive(true);
    }

}
