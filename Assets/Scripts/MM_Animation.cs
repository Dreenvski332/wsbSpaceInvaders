using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MM_Animation : MonoBehaviour
{
    public bool moveLeft;
    public float player_speed = 75;
    public float leftpeak = 310;
    public float rightpeak = 670;

    void Start()
    {
        moveLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft == true)
        {
            transform.Translate(-player_speed * Time.deltaTime, 0, 0);
            if (transform.position.x <= leftpeak) { moveLeft = false; }
        }
        else
        {
            transform.Translate(player_speed * Time.deltaTime, 0, 0);
            if (transform.position.x >= rightpeak) { moveLeft = true; }
        }
    }
}
