using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_timer : MonoBehaviour
{
    public float scene_timer = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scene_timer -= Time.deltaTime;//subtraction of timeToDeathShip and real time(Time.deltaTime)
        if (scene_timer <= 0)//if timeToDeathShip is equal or lesser then 0
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
