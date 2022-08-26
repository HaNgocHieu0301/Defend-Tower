using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI roundsText;
    public string menuSceneName = "MainMenu";
    private void OnEnable()
    {
        roundsText.text = PlayerStates.rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
