using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class levelBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxValue(int value)
    {
        slider.maxValue = value;
        slider.value = 0;
    }
    public void SetLevel(int levelPoint)
    {
        slider.value += levelPoint;  
    }
}
