using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject inGamePanel;
    public GameObject pauseGame;

    public Text txt_Point;
    public Text txt_PointEndGame;
    private int currentPoint = 0;

    private void Awake()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        pauseGame.SetActive(false);
        inGamePanel.SetActive(true);
    }

    private void Update()
    {
        PauseGame();
    }

    public void GetPoint(int point)
    {
        currentPoint++;
        txt_Point.text = "Zombie killed: " + currentPoint.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseGame.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseGame.SetActive(false);
    }

    public void EndGame()
    {
        menu.SetActive(true);
        inGamePanel.SetActive(false);
        txt_PointEndGame.text = txt_Point.text;
        Time.timeScale = 0;
    }
}
