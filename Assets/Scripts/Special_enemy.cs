using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Special_enemy : MonoBehaviour
{
    public GameObject EnemyProjectile;//GameObject for enemy projectiles - gives enemies ability to shoot
    public float time_between_projectiles_first = .5f;//variable to set fire rate of enemies
    public float time_between_projectiles = .5f;
    public float speedturn = 0; //variable to set speed of enemies moving LEFT(if number is bellow 0) or RIGHT(if number is above 0)
    public float speedforward = 75;//variable to set speed of enemies moving BACK(if number is bellow 0) or FORWARD(if number is above 0)
    public float timeToDeathShip = 500;//variable to destroy ship after certain amount of time - optimization thingy
    public float whenToStopY = 57;
    public bool moveLeft;

    public float player_speed = 10;
    public float leftpeak = 310;
    public float rightpeak = 670;

    public float health_points = 130;//variable for players overall health
    public float damage = 2;

    public Player_collision GameOver;

    // Start is called before the first frame update
    void Start()
    {
        moveLeft = true;
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
        bossLeftRigt();
        transform.Translate(0, speedforward * Time.deltaTime, 0);//makes enemies move FORWARD with speed set by variable above
        transform.Translate(-speedturn * Time.deltaTime, 0, 0);//makes enemies move RIGHT with speed set by variable above
        timeToDeathShip -= Time.deltaTime;//subtraction of timeToDeathShip and real time(Time.deltaTime)
        if (timeToDeathShip <= 0)//if timeToDeathShip is equal or lesser then 0
        {
            Destroy(gameObject);//kills enemies ships - like all of them atm
        }
        if(GameOver.health_points <= 0)//that's funny - if players HP falls bellow 0, the code for ending level is codded in boss
        {
            SceneManager.LoadScene(sceneBuildIndex: 5);//gameover
        }    
    }

    

    private void OnTriggerEnter2D(Collider2D collision)//detects collision between objects

    {
        if (collision == true)//if collision is detected
        {
            health_points -= damage;//removes 2hp from player health_points
            Debug.Log(health_points);//displays it in console
            if (health_points <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public void bossLeftRigt()//function to move boss ship to left and right after it stopped on whenToStopY
    {
        if (transform.position.y <= whenToStopY)
        {
            speedforward = 0;//sets speed to 0 and stops ship
            if (moveLeft == true)
            {

                transform.Translate(player_speed * Time.deltaTime, 0, 0);//moves ship to the left, stops on rightpeak - confusing Yeah I know
                if (transform.position.x <= rightpeak) { moveLeft = false; }//if rightpeak is achieved, sets moveLeft to false
            }
            else
            {
                transform.Translate(-player_speed * Time.deltaTime, 0, 0);//moves ship to the right, stops on leftpeak - confusing Yeah I know
                if (transform.position.x >= leftpeak) { moveLeft = true; }//if leftpeak is achieved, sets moveLeft to true
            }
        }
    }
}
