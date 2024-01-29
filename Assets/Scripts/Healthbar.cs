using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public void SetMaxHealth(float health_points)
    {
        slider.maxValue = health_points;
        slider.value = health_points;
    }

    public void SetHealth(float health_points)
    {
        slider.value = health_points;
    }
}
