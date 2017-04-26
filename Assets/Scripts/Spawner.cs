using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Range(0.0f, 2.0f)]
    public float flowDensity;
    public GameObject carPrefab;

    private float cooldown;
    private Creator passengerCarsCreator;

    private void Start()
    {
        passengerCarsCreator = new PassengerCarCreator(carPrefab);

        cooldown = flowDensity;
    }

    private void Update()
    {
        if(cooldown >= (2.5f - flowDensity))
        {
            var car = passengerCarsCreator.GetCar();
            car.transform.position = transform.position;
            cooldown = 0.0f;
        }
        else
        {
            cooldown += Time.deltaTime;
        }
    }
}
