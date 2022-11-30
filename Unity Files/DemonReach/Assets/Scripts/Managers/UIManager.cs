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
    [SerializeField] private GameObject upgradeMenu;
    
    
    [SerializeField] private GameObject bossHolder;
    private Transform[] bosses;
    [SerializeField] private Text bossCounter;
    public int bossNum;
    public int maxScore;
    public int highScore;
    public int levelNum;

    private WeaponControls weapon;


    
    void Start()
    {
        Time.timeScale = 1f;

        bossNum = 1;
        bosses = bossHolder.GetComponentsInChildren<Transform>();
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

        weapon = GameObject.Find("Player").GetComponentInChildren<WeaponControls>();

        pauseMenu.SetActive(false);
        upgradeMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //for now it's just for level one i'll update it to accomodate more levels once i know it works
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



    public void LoadScene(string name)
    {
        Time.timeScale = 1f;
        if(name == "Arena")
        {

        }
         SceneManager.LoadScene(name);
        
    }


}
