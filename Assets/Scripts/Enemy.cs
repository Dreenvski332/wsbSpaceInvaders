using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject EnemyProjectile;//GameObject for enemy projectiles - gives enemies ability to shoot
    public float time_between_projectiles = .5f;//variable to set fire rate of enemies
    public float speedturn = 10; //variable to set speed of enemies moving LEFT(if number is bellow 0) or RIGHT(if number is above 0)
    public float speedforward = 10;//variable to set speed of enemies moving BACK(if number is bellow 0) or FORWARD(if number is above 0)
    public float timeToDeathShip = 20;//variable to destroy ship after certain amount of time - optimization thingy
    const float killbox = -330;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time_between_projectiles -= Time.deltaTime;//subtraction of time_between_projectiles and real time(Time.deltaTime)
        if (time_between_projectiles < 0)//if time_between_projectiles is lesser the 0
        {
            Instantiate(EnemyProjectile, transform.position, transform.rotation);//shoots one projectile
            time_between_projectiles = .5f;//resets time
        }
        transform.Translate(0, speedforward * Time.deltaTime, 0);//makes enemies move FORWARD with speed set by variable above
        transform.Translate(-speedturn * Time.deltaTime, 0, 0);//makes enemies move RIGHT with speed set by variable above
        timeToDeathShip -= Time.deltaTime;//subtraction of timeToDeathShip and real time(Time.deltaTime)
        if (timeToDeathShip <= 0)//if timeToDeathShip is equal or lesser then 0
        {
            Destroy(gameObject);//kills enemies ships - like all of them atm
        }
    }
}
