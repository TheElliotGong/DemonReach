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
    // Start is called before the first frame update
    void Start()
    {
        facingRight = false;
        grounded = true;
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        //check if you are lower than hero and if within range of platform
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        grounded = groundCheck.IsTouchingLayers(platformLayer);
    }
}
