using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject tutorial; 


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenTutorial()
    {
        tutorial.SetActive(true);
        menu.SetActive(false);
    }

    public void OpenMenu()
    {
        tutorial.SetActive(false);
        menu.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
