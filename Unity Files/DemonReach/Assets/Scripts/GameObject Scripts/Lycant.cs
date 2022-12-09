using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class Lycant : MonoBehaviour
{
    public float maxHealth;
    public float health;
    
    [SerializeField] public float speed;
    private Vector2 velocity;
    private bool onGround;
    private bool facingRight;
    public float gravitationalAcceleration;
    public GameObject upgradeMenu;
    public GameObject player;
    public Player playerScript;
    public Transform sprite;
    
    
    public Animator animation;
    public Image hpBar;
    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        health = 300;
        maxHealth = health;
        velocity = new Vector2(speed, 0);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //horizontal movement (quite simple for now, will implement jumping next)
        if(player.transform.position.x > transform.position.x)
        {
            velocity.x = speed;
        }

        else if(player.transform.position.x < transform.position.x)
        {
            velocity.x = -speed;
        }
        if(Math.Abs(player.transform.position.x - transform.position.x) <= 5)
        {
            velocity.x = 0;
        }

        //no need to code in jump mechanics cause first boss
       
        transform.Translate(velocity * Time.deltaTime);
        Flip();
    }
    private void Flip()
    {
        if((velocity.x < -50.0f && facingRight )|| (!facingRight && velocity.x > 50.0f))
        {
            facingRight = !facingRight;
            Vector3 newLocalScale = sprite.localScale;
            newLocalScale.x *= -1;
            sprite.localScale = newLocalScale;
        }
        animation.SetFloat("velocity_X", velocity.x);

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
