using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    public void QuitGame()
    {
        print("Quit game");
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Tutorial()
    {
        print("open tutorial page");
        SceneManager.LoadScene("Tutorial");
    }
}
