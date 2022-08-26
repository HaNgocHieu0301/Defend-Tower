using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CompleteLevelUI : MonoBehaviour
{
    public string menuSceneName = "MainMenu";
    public string nextLevel = "level2";
    public int levelUnlock = 2;

    public void NextLevel()
    {
        PlayerPrefs.SetInt("levelReached", levelUnlock);
        SceneManager.LoadScene(nextLevel);
    }

    public void Menu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
