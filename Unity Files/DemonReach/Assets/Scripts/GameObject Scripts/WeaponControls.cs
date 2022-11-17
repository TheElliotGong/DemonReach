using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControls : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera cam;
    private Vector3 mousePos;
    public GameObject projectile;
    public Transform projectileTransform;
    public bool canFire;
    public float timeBetweenFiring;
    private float timer;

    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 rotation = mousePos - transform.position;
        float degree = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, degree);
        Fire();
    }

    void Fire()
    {
        if(canFire == false)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        if(Input.GetMouseButton(0) && canFire == true)
        {
            canFire = false;
            GameObject bullet = Instantiate(projectile, projectileTransform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * 1100, ForceMode2D.Impulse);
        }
    }
}
