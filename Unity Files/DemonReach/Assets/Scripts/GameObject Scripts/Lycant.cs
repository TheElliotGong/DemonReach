using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lycant : MonoBehaviour
{
    private int health;
    [SerializeField] public float speed;
    private Vector2 velocity;
    private bool onGround;
    [SerializeField] public GameObject lycan;
    [SerializeField] public GameObject player;
    [SerializeField] public Player playerScript;
    [SerializeField] public float gravitationalAcceleration;
    [SerializeField] public List<GameObject> jumpTriggers;
    [SerializeField] private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        health = 300;
        velocity = new Vector2(speed, 0);
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
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
            velocity = new Vector2(-speed, 0);
        }

        //now if im on a platform it should head torwards the closest platform
        if(player.transform.position.y > -43)
        {
            for (int i = 0; i < jumpTriggers.Count; i++)
            {
                //do i have to make x = 380 as precondition for it to be on the floor?
                if (jumpTriggers[i].transform.position.y == -455)
                {
                    Debug.Log("this actually works");

                }
            }
        }
       
        transform.Translate(velocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.transform.tag == "PlayerBlast")
        {
            health = health - 20;
            Debug.Log("hit");
        }


        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //now i need to figure out when the player on the platform
        if(player.transform.position.y > -43)
        {
            
        }
    }
}
