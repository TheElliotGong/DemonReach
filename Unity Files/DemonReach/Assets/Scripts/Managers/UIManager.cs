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
    private GameObject upgradeMenu;
    private GameObject defeatScreen;    
    private GameObject bossHolder;

    private GameObject currentBoss;

    private Text bossCounter;
    private Player player;

    public int bossNum = 1;
    public int maxScore;
    public int highScore;
    public int levelNum;

    public List<GameObject> bosses;
    


    
    void Start()
    {
        Time.timeScale = 1f;
        pauseMenu = GameObject.Find("Pause_UI");
        upgradeMenu = GameObject.Find("Upgrades");
        defeatScreen = GameObject.Find("Defeat");
        player = GameObject.Find("Player").GetComponent<Player>();
        //bossHolder = GameObject.Find("Bosses");
        currentBoss = bosses[0];
        
        bossCounter = GameObject.Find("Boss_Counter").GetComponent<Text>();
        
        /*
        for(int i = 0; i < bosses.Length; i++)
        {
            if(bossNum - 1 == i)
            {
                bosses[i].gameObject.SetActive(true);
            }
            else
            {
                bosses[i].gameObject.SetActive(false);
            }
        }
        */
        

        pauseMenu.SetActive(false);
        upgradeMenu.SetActive(false);
        defeatScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //for now it's just for level one i'll update it to accomodate more levels once i know it works
        CheckDeath();
        
    }
    public void NextBoss()
    {
        bossNum++;
        bossCounter.text = "Boss " + bossNum;
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

    public void CheckDeath()
    {
        if (player.hp <= 0)
        {
            defeatScreen.SetActive(true);
            Time.timeScale = 0f;
        }
            
    }

    public void LoadScene(string name)
    {
        Time.timeScale = 1f;
        if(name == "Arena")
        {

        }
         SceneManager.LoadScene(name);
        
    }


}
