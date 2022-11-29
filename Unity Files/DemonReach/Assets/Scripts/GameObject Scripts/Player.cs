using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update


    public float speed;
    public float hp;
    public float maxHP;
    public float jumpForce;
    public float bulletSpeed;
    public float bulletDmg;

    private float knockBackTimer;
    private float horizontal;
    private bool facingRight;
    private bool grounded;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private CapsuleCollider2D groundCheck;
    [SerializeField] private LayerMask platformLayer;

    /// <summary>
    /// Set the player script instance
    /// </summary>



    private void Start()
    {
        knockBackTimer = 0.0f;
        horizontal = 0;
        facingRight = true;
        grounded = true;
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        grounded = groundCheck.IsTouchingLayers(platformLayer);
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);

        }
        Flip();
    }
    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(horizontal * speed, rigidBody.velocity.y);
    }
    /// <summary>
    /// Flip the sprite depending on the direction the player is moving in.
    /// </summary>
    private void Flip()
    {
        if (facingRight == true && horizontal < 0.0f || facingRight == false && horizontal > 0.0f)
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1.0f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //code in knock back here
        if (collision.gameObject.tag == "Enemy")
        {
            hp -= 2;
            Debug.Log("player hit");
            //knockback
            /*
            if (collision.transform.position.y < rigidBody.transform.position.y)
            {
                float angle = Mathf.Atan((rigidBody.transform.position.y - collision.transform.position.y) / (Mathf.Abs(rigidBody.transform.position.x - collision.transform.position.x)))
                    * 180 / Mathf.PI;
                if (collision.transform.position.x > transform.position.x)
                {
                    rigidBody.AddForce(new Vector2(-750 * Mathf.Cos(angle), 750 * Mathf.Sin(angle)));
                }
                else if (collision.transform.position.x < transform.position.x)
                {
                    rigidBody.AddForce(new Vector2(750 * Mathf.Cos(angle), 750 * Mathf.Sin(angle)));
                }
            }*/
            if (collision.transform.position.x > transform.position.x)
            {
                rigidBody.velocity = new Vector2(-500, 500);
                //collision.transform.Translate(new Vector3(-500, 0, 0), Space.World);
            }

            else if (collision.transform.position.x < transform.position.x)
            {
                rigidBody.velocity = new Vector2(500, 500);
                //collision.transform.Translate(new Vector3(-500, 0, 0), Space.World);
            }
            
            
            
        }
        //hope this bounces each other off

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public bool Grounded { get { return grounded; } }
}
