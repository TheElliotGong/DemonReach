using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Image healthBar;
 
    private Player player;
    private Lycant lycant;
    public bool isPlayer;
    void Start()
    {
        healthBar = gameObject.GetComponent<Image>();
        if(isPlayer == true)
        { 
            player = GameObject.Find("Player").GetComponent<Player>();
        }
        else 
        {
            lycant = GameObject.Find("Lycan").GetComponent<Lycant>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayer)
        {
            healthBar.fillAmount = player.hp / player.maxHP;

        }
        else
        {
            healthBar.fillAmount = lycant.health / lycant.maxHealth;
        }
        
    }
}
