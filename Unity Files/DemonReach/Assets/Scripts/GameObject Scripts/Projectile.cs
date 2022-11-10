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


    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage()
    {

    }
}
