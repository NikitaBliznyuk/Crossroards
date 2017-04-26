using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Range(0.5f, 2.0f)]
    public float flowDensity;
    public GameObject carPrefab;
    public Vector2 direction;

    private float cooldown;
    private Creator passengerCarsCreator;
    private float offset = 0.33f;

    private void Start()
    {
        passengerCarsCreator = new PassengerCarCreator(carPrefab);

        cooldown = flowDensity;
    }

    private void Update()
    {
        if(cooldown >= (2.5f - flowDensity))
        {
            var car = passengerCarsCreator.GetCar(direction);
            var multiplier = Random.Range(0, 2);
            multiplier = multiplier == 0 ? -1 : 1;
            var position = transform.position + new Vector3(direction.y, direction.x) * offset * multiplier;
            car.transform.position = position;
            cooldown = 0.0f;
        }
        else
        {
            cooldown += Time.deltaTime;
        }
    }
}
