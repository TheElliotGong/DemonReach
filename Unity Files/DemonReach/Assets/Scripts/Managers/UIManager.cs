using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;


public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private TextMesh score;
    
    public int playerScore;
    public int maxScore;
    public int highScore;
    public int levelNum;
    
     private bool finished;
    [SerializeField] private GameObject[] potions;
    [SerializeField] private Sprite[] potionImages;
    void Start()
    {
        Time.timeScale = 1f;
        finished = false;
        playerScore = 0;

        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //for now it's just for level one i'll update it to accomodate more levels once i know it works
    }
    public void UpdateScore(int points)
    {

        playerScore += points;
        score.text = playerScore.ToString();
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ShowLevelResult()
    {
        Time.timeScale = 0f;
        if (playerScore >= highScore)
        {
            highScore = playerScore;
        }
        //levelResult.SetActive(true);
        ShowPotionsAchieved();
        

    }

    public void LoadScene(string name)
    {
        Time.timeScale = 1f;

         SceneManager.LoadScene(name);
        if(name == "Level_Select")
        {
            AudioManager.instance.SetAudio(0);

        }
        else if(name == "Victory")
        {
            AudioManager.instance.SetAudio(4);

        }
    }

    public void ShowPotionsAchieved()
    {
        float currentPercentage = (float)(playerScore) / (float)(maxScore);
        float highScorePercentage = 0f;
        //update the player's high score percentage if the high score is actually greater than 0.
        if(highScore > 0)
        {
            highScorePercentage = (float)(highScore) / (float)(maxScore);
        }
        //Show star rating if the current score is at least a third of the max possible score.
        if (currentPercentage >= 0.33f )
        {
            //nextButton.SetActive(true);
            AudioManager.instance.SetAudio(2);
            potions[0].GetComponent<Image>().sprite = potionImages[1];
            if(currentPercentage >= 0.66f)
                potions[1].GetComponent<Image>().sprite = potionImages[1];
            if(currentPercentage >= 0.9f)
                potions[2].GetComponent<Image>().sprite = potionImages[1];
            
            
        }
        //Make sure that the player's score is saved.
        else
        {
            //nextButton.SetActive(false);
            //Only set completed as false if the high score isn't greater than 33 percent.

        }



    }

}
