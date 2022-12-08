using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Upgrade : MonoBehaviour
{
    // Start is called before the first frame update
    public int type;
    
    public Text upgradeName;
    public Image image;
    public GameObject chosenUpgrades;
    public GameObject upgradeIcon;
    
    public List<Sprite> buttonImages;
    private Player player;
    private GameObject upgradeMenu;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        //ui = GameObject.Find("hud").GetComponent<UIManager>();

        upgradeMenu = GameObject.Find("Upgrades");

    }

    public void SetUpgrade(string text, Sprite img)
    {
        upgradeName.text = text;
        
    }
    public void SetType(int value)
    {
        switch(value)
        {
            case 1:
                image.sprite = buttonImages[0];
                upgradeName.text = "HP Boost";
                break;
            case 2:
                image.sprite = buttonImages[1];
                upgradeName.text = "Speed Boost";
                break;
            case 3:
                image.sprite = buttonImages[2];
                upgradeName.text = "+ Bullet Speed";
                break;
            case 4:
                image.sprite = buttonImages[3];
                upgradeName.text = "+ Bullet Dmg";
                break;
        }
    }
    /// <summary>
    /// Change upgrade option when loaded in the next update phase.
    /// </summary>
    // Update is called once per frame
    public void UpgradeStat()
    {
        GameObject upgrade = Instantiate(upgradeIcon);
        switch(type)
        {
            //Extra hp
            case 1:
                player.hp *= 1.25f;
                upgrade.GetComponent<Image>().sprite = buttonImages[0];
                break;
            //Extra speed
            case 2:
                player.speed *= 1.25f;
                upgrade.GetComponent<Image>().sprite = buttonImages[1];
                break;
            //Extra bullet speed
            case 3:
                player.bulletSpeed *= 1.25f;
                upgrade.GetComponent<Image>().sprite = buttonImages[2];
                break;
            //Extra bullet dmg
            case 4:
                player.bulletDmg *= 1.25f;
                upgrade.GetComponent<Image>().sprite = buttonImages[3];
                break;
        }
        upgrade.transform.parent = chosenUpgrades.transform;
        upgradeMenu.SetActive(false);
        Time.timeScale = 1.0f;

       

    }


}
