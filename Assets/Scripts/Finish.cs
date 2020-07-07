using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}