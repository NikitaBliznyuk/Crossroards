using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Car;

public class PassengerCarCreator : Creator
{
    public PassengerCarCreator(GameObject carInstance) : base(carInstance)
    {

    }

    public override GameObject GetCar(Vector2 direction)
    {
        var car = GameObject.Instantiate(carInstance);

        var characteristics = car.GetComponent<Characteristics>();
        characteristics.Set(5.0f, Color.blue, direction);

        var spriteRenderer = car.GetComponent<SpriteRenderer>();
        spriteRenderer.color = characteristics.CarColor;

        return car;
    }
}
