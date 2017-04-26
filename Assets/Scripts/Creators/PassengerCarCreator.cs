using System.Collections.Generic;
using UnityEngine;

using Car;

public class PassengerCarCreator : Creator
{
    private List<Color> colors = new List<Color>();

    public PassengerCarCreator(GameObject carInstance) : base(carInstance)
    {
        colors.AddRange(new List<Color>() { Color.green, Color.blue, Color.red });
    }

    public override GameObject GetCar(Vector2 direction)
    {
        var car = GameObject.Instantiate(carInstance);

        var characteristics = car.GetComponent<Characteristics>();
        characteristics.Set(5.0f, colors[Random.Range(0, colors.Count)], direction);

        var spriteRenderer = car.GetComponent<SpriteRenderer>();
        spriteRenderer.color = characteristics.CarColor;

        return car;
    }
}
