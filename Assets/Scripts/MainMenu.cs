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
        object value = GameObject.mainMenu.SetActive(false);
        object value = GameObject.menuCredits.SetActive(true);
    }
    public void Menu()
    {
        object value = GameObject.gameObject.menuCredits.SetActive(false);
        object value = GameObject.mainMenu.SetActive(true);
    }

}
