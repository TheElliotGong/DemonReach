using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControls : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera cam;
    private Vector3 cursorPos;
    public GameObject projectile;
    public bool canFire;
    public float timeBetweenFiring;
    private float timer;

    private void Update()
    {
        cursorPos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = cursorPos - transform.position;
        float degree = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, degree);
    }

    void Fire()
    {
        if(canFire == false)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {

            }
        }
    }
}
