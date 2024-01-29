using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class side_cannons : MonoBehaviour
{
    public GameObject EnemyProjectile;//GameObject for enemy projectiles - gives enemies ability to shoot
    public float time_between_projectiles_first = .2f;//variable to set fire rate of enemies
    public float time_between_projectiles = .2f;
    public float timeToDeathShip = 500;//variable to destroy ship after certain amount of time - optimization thingy

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
            time_between_projectiles = time_between_projectiles_first;//resets time
        }
        timeToDeathShip -= Time.deltaTime;//subtraction of timeToDeathShip and real time(Time.deltaTime)
        if (timeToDeathShip <= 0)//if timeToDeathShip is equal or lesser then 0
        {
            Destroy(gameObject);//kills enemies ships - like all of them atm
        }
    }
}
