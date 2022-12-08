using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void LevelSelect(int levelNumber)
    {
        Debug.Log($"{levelNumber} lvl number");
        SceneManager.LoadScene(levelNumber + 1);
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
