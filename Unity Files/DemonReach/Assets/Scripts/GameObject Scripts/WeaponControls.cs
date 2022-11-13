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
        //transform.Rotate(new Vector3(0.0f, 0.0f, degree));
        //transform.eulerAngles = new Vector3(0, 0, degree);
        /*
        if(mousePos.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
        }*/
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
            Instantiate(projectile, projectileTransform.position, Quaternion.identity);
        }
    }
}
