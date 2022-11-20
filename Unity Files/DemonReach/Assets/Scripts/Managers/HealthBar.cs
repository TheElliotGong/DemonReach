using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update

    private Image healthBar;
    public float currentHealth;
    public float maxHealth;
    public Player playerScript;
    
    void Start()
    {
        healthBar = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = playerScript.hp;
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
