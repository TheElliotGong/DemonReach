using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update

    private Image healthBar;
    private Player player;
    
    void Start()
    {
        healthBar = gameObject.GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = player.hp / player.maxHP;
    }
}
