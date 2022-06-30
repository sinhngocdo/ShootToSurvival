using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject inGamePanel;
    public Text txt_Point;
    public Text txt_PointEndGame;
    private int currentPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        inGamePanel.SetActive(true);
        txt_Point.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void EndGame()
    {
        menu.SetActive(true);
        inGamePanel.SetActive(false);
        txt_Point.gameObject.SetActive(false);
        txt_PointEndGame.text = txt_Point.text;
        Time.timeScale = 0;
    }
}
