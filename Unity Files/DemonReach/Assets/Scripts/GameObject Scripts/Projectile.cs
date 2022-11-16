using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    public enum ProjectileType { player, enemy};
    // Start is called before the first frame update
    public float damage;
    public float speed;

    public ProjectileType projectileType;
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
        direction = direction.normalized;
        Vector3 rotation = transform.position - mousePos;
        rotation = rotation.normalized;
        rigidBody.velocity = new Vector2(direction.x, direction.y).normalized * speed;
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle );
    }
    void Update()
    {
        
    }

    public void DealDamage()
    {

    }


}
