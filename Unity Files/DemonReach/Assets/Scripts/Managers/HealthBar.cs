using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Image healthBar;
    public Player player;
    public Lycant lycant;

    public bool isPlayer;
    void Start()
    {
        
        if(isPlayer == true)
        { 
            player = GetComponent<Player>();
        }
        else 
        {
            lycant = GetComponent<Lycant>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayer == true)
        {
            healthBar.fillAmount = player.hp / player.maxHP;

        }
        else
        {
            healthBar.fillAmount = lycant.health / lycant.maxHealth;
        }
        
    }
}
