using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LycanthropeAI : MonoBehaviour
{
    public float speed;
    public float horizontal;
    private int health;

    public float jumpForce;
    public bool facingRight;
    public bool grounded;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private CapsuleCollider2D groundCheck;
    [SerializeField] private LayerMask platformLayer;

    public Player player;
    public GameObject playerSprite;
    // Start is called before the first frame update
    void Start()
    {
        facingRight = false;
        grounded = true;
        rigidBody = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        grounded = groundCheck.IsTouchingLayers(platformLayer);

        rigidBody.velocity = new Vector2(playerSprite.transform.position.x - transform.position.x, 0);
        rigidBody.velocity = rigidBody.velocity.normalized * speed;
        //check if you are lower than hero and if within range of platform (maybe?)
        if (playerSprite.transform.position.y > transform.position.y + 200 && grounded)
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
        if (facingRight == true && horizontal < 0.0f || facingRight == false && horizontal > 0.0f)
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1.0f;
            transform.localScale = localScale;
        }
    }
}
