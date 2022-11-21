using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update

    private Image healthBar;
    
    
    void Start()
    {
        healthBar = gameObject.GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Player.instance.hp / Player.instance.maxHP;
    }
}
