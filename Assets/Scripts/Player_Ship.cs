using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Ship : MonoBehaviour
{
    public GameObject Projectile; //creates sort of variable for simple player-shot projectiles - not a true variable, a thingy called gameobject
    public GameObject Player_rocket; //creates sort of variable for simple player-shot projectiles, but this time for special attack - not a true variable, a thingy called gameobject
    const float Boundary_top = 623, Boundary_bot = 1, Boundary_right = 834, Boundary_left = 1; //creates boundaries so that player cannot leave area covered by the camera
    public float Rockets_number = 10;
    public Rocketsbar rocketsbar;
    public Special_enemy MoveLevels;

    IEnumerator Rocket()//Coroutine - it has the ability to stop only certain parts of script
    {
        Instantiate(Player_rocket, transform.position, transform.rotation);//spawns one player_rocket
        yield return new WaitForSeconds(.1f);//halts script for 0.1 second
        Instantiate(Player_rocket, transform.position, transform.rotation);//spawns second player_rocket
        yield return new WaitForSeconds(.1f);//hatls script for another 0.1 second
        Instantiate(Player_rocket, transform.position, transform.rotation);//spanws third player_rocket - giving this three projectiles attack per one click of a button
    }
    IEnumerator SwitchLevels()//Coroutine - it has the ability to stop only certain parts of script
    {
        yield return new WaitForSeconds(3f);//halts script for 0.1 second
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        rocketsbar.SetMaxRockets(Rockets_number);
    }

    // Update is called once per frame
    void Update()
    {
        float player_speed = 300;//variable that sets how fast a player will move

        if (Input.GetKey("d"))//when "d" is pressed the main ship position in changed - 'player_speed' * time in seconds - a simple movement function
        {
            transform.Translate(player_speed * Time.deltaTime, 0, 0);//moves player to the - right
        }
        if (Input.GetKey("a"))//when "a" is pressed the main ship position in changed - 'player_speed' * time in seconds - a simple movement function
        {
            transform.Translate(-player_speed * Time.deltaTime, 0, 0);//moves player to the - left
        }
        if (Input.GetKey("w"))//when "w" is pressed the main ship position in changed - 'player_speed' * time in seconds - a simple movement function
        {
            transform.Translate(0, player_speed * Time.deltaTime, 0);//moves player - forward
        }
        if (Input.GetKey("s"))//when "s" is pressed the main ship position in changed - 'player_speed' * time in seconds - a simple movement function
        {
            transform.Translate(0, -player_speed * Time.deltaTime, 0);//moves player - back
        }
        if (Input.GetKeyDown("space"))//when "space" or " " is pressed it spawns a projectile that will go forward 
        {
            Instantiate(Projectile, transform.position, transform.rotation);//takes position and rotation from player_ship and spawns projectile based on that
        }
        if (Input.GetKeyDown("c"))//when "c" is pressed - activates 'Rocket' Coroutine from above
        {
            if (Rockets_number > 0)
            {
                StartCoroutine("Rocket");
                Rockets_number -= 1;
                rocketsbar.SetRockets(Rockets_number);
            }
            else { Debug.Log("No More Rockets!"); }
        }

        if (transform.position.x > Boundary_right) transform.position = new Vector3(Boundary_right, transform.position.y, 0);//forbids player from leaving camera view to the right
        if (transform.position.x < Boundary_left) transform.position = new Vector3(Boundary_left, transform.position.y, 0);//forbids player from leaving camera view to the left
        if (transform.position.y > Boundary_top) transform.position = new Vector3(transform.position.x, Boundary_top, 0);//forbids player from leaving camera view on front
        if (transform.position.y < Boundary_bot) transform.position = new Vector3(transform.position.x, Boundary_bot, 0);//forbids player from leaving camera view to the back

        if(MoveLevels.health_points <= 0)
        {
            StartCoroutine("SwitchLevels");
        }
    }

}
