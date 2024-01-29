using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_Animation : MonoBehaviour
{
    public float player_speed = 75;
    public float rightpeak = 790;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-player_speed * Time.deltaTime, 0, 0);
        if (transform.position.x >= rightpeak)
        {
            transform.position = new Vector3(-70, transform.position.y, 0);
        }
    }
}
