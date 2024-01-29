using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour 
{ 
    public float health_points = 100;//variable for players overall health
    public float damage = 2;
    private void OnTriggerEnter2D(Collider2D collision)//detects collision between objects
    
    {
       if(collision == true)//if collision is detected
        {
            health_points -= damage;//removes 2hp from player health_points
            Debug.Log(health_points);//displays it in console
            if(health_points <= 0)
            {
                Destroy(gameObject);//destroy object if health_points fall bellow 0
            }
        }
    }
}
