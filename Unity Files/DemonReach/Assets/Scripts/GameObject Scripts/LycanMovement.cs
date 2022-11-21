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
    [SerializeField] public float gravitationalAcceleration;
    // Start is called before the first frame update
    void Start()
    {
        health = 300;
        velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collisison2D collision)
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
}
