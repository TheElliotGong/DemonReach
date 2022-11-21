using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static Player instance;
   
    public float speed;
    public float hp;
    public float maxHP;
    public float jumpForce;
    public float bulletSpeed;
    public float bulletDmg;
    
    private float horizontal;
    private bool facingRight;
    private bool grounded;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private CapsuleCollider2D groundCheck;
    [SerializeField] private LayerMask platformLayer;
    
    /// <summary>
    /// Set the player script instance
    /// </summary>
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }


    private void Start()
    {
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
    private void Flip()
    {
        if(facingRight == true && horizontal < 0.0f || facingRight == false && horizontal > 0.0f)
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
        hp = hp - 2;
        //hope this bounces each other off

        if(hp == 0)
        {
            Destroy(gameObject);
        }
    }
}
