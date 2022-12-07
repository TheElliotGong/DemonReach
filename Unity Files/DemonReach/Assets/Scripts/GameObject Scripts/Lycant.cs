using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lycant : MonoBehaviour
{
    public float maxHealth;
    public float health;
    
    [SerializeField] public float speed;
    private Vector2 velocity;
    private bool onGround;

    [SerializeField] public GameObject player;
    [SerializeField] public Player playerScript;
    [SerializeField] public float gravitationalAcceleration;
    [SerializeField] public List<GameObject> jumpTriggers;

    public GameObject upgradeMenu;
    public Image hpBar;
    // Start is called before the first frame update
    void Start()
    {
        health = 300;
        maxHealth = health;
        velocity = new Vector2(speed, 0);

        upgradeMenu = GameObject.Find("Upgrades");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //horizontal movement (quite simple for now, will implement jumping next)
        if(player.transform.position.x > transform.position.x)
        {
            velocity = new Vector2(speed, 0);
        }

        else if(player.transform.position.x < transform.position.x)
        {
            velocity = new Vector2(-speed, 0);
        }

        //no need to code in jump mechanics cause first boss
       
        transform.Translate(velocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.transform.tag == "PlayerBlast")
        {
            health -= playerScript.bulletDmg;
            hpBar.fillAmount = health / maxHealth;
            if(health <= 0)
            {

                hpBar.fillAmount = 0.0f;
                upgradeMenu.SetActive(true);
                Time.timeScale = 0.0f;
                Destroy(gameObject);
                
            }
        }
        
    }


}
