using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float horizontal;
    public float speed;
    public float jumpForce;
    public bool facingRight;
    public bool grounded;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask platformLayer;
    private Vector2 size;
    private void Start()
    {
        size.x = 1.0f;
        size.y = 1.0f;
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        }
        if(Input.GetKeyDown(KeyCode.W) && rigidBody.velocity.y > 0f && IsGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y * 0.5f);
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

    private bool IsGrounded()
    {
        //bool isGrounded = Physics2D.OverlapBox(groundCheck.position, size, platformLayer);
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, platformLayer);
        grounded = isGrounded;
        return isGrounded;
    }
       
}
