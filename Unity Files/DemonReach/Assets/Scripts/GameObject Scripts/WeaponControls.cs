using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControls : MonoBehaviour
{
    // Start is called before the first frame update

    private Camera cam;
    private Vector3 mousePos;
    private Player playerScript;

    public GameObject pauseMenu;
    public GameObject upgradeMenu;
    public GameObject projectile;
    public Transform projectileHolder;
    public Transform projectileTransform;

    public bool canFire;

    public float timeBetweenFiring;
    private float timer;
    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();


    }
    private void Update()
    {
        if(pauseMenu.activeSelf == false || upgradeMenu.activeSelf == false)
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
            Vector3 rotation = mousePos - transform.position;
            float degree = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, degree);
            Fire();
        }
        
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
            bullet.transform.parent = projectileHolder;
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * playerScript.bulletSpeed, ForceMode2D.Impulse);
        }
    }
}
