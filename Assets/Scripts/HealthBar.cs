using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    /**
     * Code from;
     * https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=633s
     */

    [SerializeField] private Slider slider = null;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
