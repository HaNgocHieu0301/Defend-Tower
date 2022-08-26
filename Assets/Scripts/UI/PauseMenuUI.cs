using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuUI : MonoBehaviour
{
    public GameObject ui;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            ToggleStatus();
        }
    }

    void ToggleStatus()
    {
        ui.SetActive(!ui.activeSelf);
        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ToggleStatus();
    }
    public void Continue()
    {
        ToggleStatus();
    }
    public void Menu()
    {
        ToggleStatus();
        SceneManager.LoadScene("MainMenu");
    }
}
