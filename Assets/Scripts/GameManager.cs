using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static bool endGame;
    public GameObject gameOverPanel;
    public GameObject completeLevelPanel;

    private void Start()
    {
        endGame = false;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            EndGame();
        }
        if (endGame)
        {
            return;
        }
        if (PlayerStates.lives <= 0)
        {
            EndGame();
        }
    }
    public void EndGame()
    {
        endGame = true;
        gameOverPanel.SetActive(true);
    }
    public void WinLevel()
    {
        endGame = true;

    }
}
