using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocketsbar : MonoBehaviour
{
    public Slider slider;
    public void SetMaxRockets(float Rockets_number)
    {
        slider.maxValue = Rockets_number;
        slider.value = Rockets_number;
    }

    public void SetRockets(float Rockets_number)
    {
        slider.value = Rockets_number;
    }
}
