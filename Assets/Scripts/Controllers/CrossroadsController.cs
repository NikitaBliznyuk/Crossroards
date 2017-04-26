using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossroadsController : MonoBehaviour
{
    public float LightTime { get; set; }

    public TrafficLightController[] verticalLights;
    public TrafficLightController[] horizontalLights;

    private float currentTime;

    private void Start()
    {
        LightTime = 1.0f;
        currentTime = 0.0f;
    }

    public void StartHorizontal()
    {
        currentTime = 0.0f;
    }

    public void StartVertical()
    {
        currentTime = LightTime;
    }

    private void Update()
    {
        for (var i = 0; i < horizontalLights.Length; i++)
        {
            horizontalLights[i].ToggleState(currentTime < LightTime);
            verticalLights[i].ToggleState(currentTime >= LightTime);
        }

        currentTime = currentTime >= 10.0f ? 0.0f : currentTime + Time.deltaTime;
    }
}
