using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LycanMovement : MonoBehaviour
{
    private int health;
    [SerializeField] public float speed;
    private Vector2 velocity;
    private bool onGround;
    [SerializeField] public GameObject lycan;
    [SerializeField] public GameObject player;
    [SerializeField] public Player playerScript;
    [SerializeField] public float gravitationalAcceleration;
    // Start is called before the first frame update
    void Start()
    {
        health = 300;
        velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //horizontal movement (quite simple for now, will implement jumping next)
        if(player.transform.position.x > lycan.transform.position.x)
        {
            velocity = new Vector2(speed, 0);
        }

        else if(player.transform.position.x < lycan.transform.position.x)
        {
            velocity = new Vector2(-1 * speed, 0);
        }

        lycan.transform.Translate(velocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "PlayerBlast")
        {
            health = health - 20;
            Debug.Log("hit");
        }


        if(health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //now i need to figure out when the player on the platform
        if(player.transform.position.y > -13.5)
        {
            //need to add jump force
            velocity = new Vector2(speed, 400);
        }
    }
}
