using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    //public static bool GameIsWon = false;
    public GameObject gameWonUI;
    private BasePlayer playerController;

    // Update is called once per frame

    void Start()
    {
        playerController = FindObjectOfType<BasePlayer>();
        gameWonUI.SetActive(true);
        playerController.enabled = false;
        Time.timeScale = 0f;
    }

    //public void GameWon()
    //{
       
    //    //GameIsWon = true;
    //}

    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Debug.Log("QuittingGame");
        Application.Quit();
    }
}
