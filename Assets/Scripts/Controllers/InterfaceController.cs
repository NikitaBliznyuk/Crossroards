using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    public Text[] percents;
    public CrossroadsController controller;
    public Slider slider;

    private void Start()
    {
        UpdateCrossroad();
    }

    public void UpdateCrossroad()
    {
        controller.LightTime = slider.value;
        percents[0].text = slider.value * 10 + "%";
        percents[1].text = (slider.maxValue - slider.value + 1) * 10 + "%";
    }
}
