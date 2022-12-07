using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    [Header("Players")]
    public GameObject mainGuy;
    public Redguy redGuy;
    public Blueguy blueGuy;

    public List<Transform> objectivesToCollect = new List<Transform>();

    public GameObject gameWonUI;
    public TMP_Text objective;
    
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

       objective.text = $"Objectives: {objectivesToCollect.Count}";
       if (objectivesToCollect.Count == 0) 
        {
            print("pass level");
            GameWon();
        }

    }

    private void GameWon()
    {
        print("called");
        gameWonUI.SetActive(true);
;        //display finish level ui
        //wait for button press to transition to next level
    }
}
