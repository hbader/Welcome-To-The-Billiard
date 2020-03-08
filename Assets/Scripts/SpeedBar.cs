using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;

    public Image fill;

    public void setMaxSpeed(float speed)
    {
        slider.maxValue = speed;
    }

    public void setSpeed(float speed)
    {
        slider.value = speed;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
