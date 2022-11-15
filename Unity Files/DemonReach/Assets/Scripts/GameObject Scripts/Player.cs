using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float hp;
    public float horizontal;
    
    public float jumpForce;
    private bool facingRight;
    private bool grounded;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private CapsuleCollider2D groundCheck;
    [SerializeField] private LayerMask platformLayer;

    private void Start()
    {
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

       
}
