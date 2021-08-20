using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Controller Flappy;
    public Spawner PipeSpawner;

    public GameObject MainMenu;
    public GameObject IngameUI;

    public Text ScoreText;
    public int CurrentScore;

    public GameObject GameoverUI;

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update(){}

    public void StartGame()
    {
        //Hide main menu
        MainMenu.SetActive(false);

        //Show score text
        IngameUI.SetActive(true);
        Flappy.StartGame = true;
        PipeSpawner.StartGame = true;
    }

    public void GameOver()
    {
        //make the game freeze
        Time.timeScale = 0;

        IngameUI.SetActive(false);
        GameoverUI.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void AddScore()
    {
        CurrentScore++;
        ScoreText.text = CurrentScore.ToString();
    }
}
