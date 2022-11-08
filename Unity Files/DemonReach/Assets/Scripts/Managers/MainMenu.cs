using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static MainMenu instance;
    private void Start()
    {

        if (SceneManager.GetActiveScene().name == "Menu")
            AudioManager.instance.SetAudio(1);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level_Select");
    }

    public void QuitGame()
    {
        Debug.Log("You quit the game!");
        Application.Quit();
    }

    public void OpenCredits()
    {

        SceneManager.LoadScene("Credits");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        AudioManager.instance.SetAudio(0);
    }
}
