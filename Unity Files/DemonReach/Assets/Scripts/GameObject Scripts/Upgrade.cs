using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class Upgrade : MonoBehaviour
{
    // Start is called before the first frame update
    public int type;
    public Player playerScript;
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();

    }
    /// <summary>
    /// Change upgrade option when loaded in the next update phase.
    /// </summary>
    public void Randomize()
    {

    }
    // Update is called once per frame
    public void UpgradeStat()
    {
        switch(type)
        {
            case 1:
                playerScript.hp *= 1.5f;
                break;
            case 2:
                playerScript.speed *= 1.5f;
                break;
            case 3:

                break;
            case 4:
                break;
        }
    }
}
