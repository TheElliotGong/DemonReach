using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Upgrade : MonoBehaviour
{
    // Start is called before the first frame update
    public int type;
    public List<Sprite> buttonImages;
    private Image image;
    public Text upgradeName;
    void Start()
    {
        //Load proper image based on upgrade type.
        image = gameObject.GetComponent<Image>();
        switch(type)
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
        switch(type)
        {
            //Extra hp
            case 1:
                Player.instance.hp *= 1.25f;
                break;
            //Extra speed
            case 2:
                Player.instance.speed *= 1.25f;
                break;
            //Extra bullet speed
            case 3:
                Player.instance.bulletSpeed *= 1.25f;
                break;
            //Extra bullet dmg
            case 4:
                Player.instance.bulletDmg *= 1.25f;
                break;
        }
    }
}
