using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    public enum ProjectileType { player, enemy};
    // Start is called before the first frame update
    public ProjectileType projectileType;
    public float damage;
    public float speed;

    
    private Camera cam;

    private Rigidbody2D rigidBody;
    private Vector3 mousePos;
    // Update is called once per frame

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        
        Vector3 direction = mousePos - transform.position;

        Vector3 rotation = transform.position - mousePos;
        //rigidBody.velocity = new Vector2(direction.x, direction.y).normalized * speed;
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle );
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Wall")
            Destroy(gameObject);
        else if(collision.transform.tag == "Player")
        {

        }
    }

    

    public void DealDamage()
    {

    }


}
