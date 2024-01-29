using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Movement : MonoBehaviour
{
    public float timeToDeath = 10;//timer for projectile to be deleted - optimization thingy - you don't want them objects just clogging up your ram
    // Start is called before the first frame update
    public float Projectal_speed = 400;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0 , Projectal_speed * Time.deltaTime, 0);//spped of the projectile
        timeToDeath -= Time.deltaTime;//subtraction of timeToDeath, based on real time (Time.deltaTime)
        if(timeToDeath <= 0)//if timeToDeath reaches 0
        {
            Destroy(gameObject);//kills projectiles
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//detects collision between objects
    {
        if (collision == true)//if collision is detected deletes projetile that collided with player_ship
        {
            Destroy(gameObject);
        }
    }
}
