using System.Collections.Generic;
using UnityEngine;

using Car;

public class PassengerCarCreator : Creator
{
    private List<Color> colors = new List<Color>();
    private float fovValue = 2.0f;

    public PassengerCarCreator(GameObject carInstance) : base(carInstance)
    {
        colors.AddRange(new List<Color>() { Color.green, Color.blue, Color.red });
    }

    public override GameObject GetCar(Vector2 direction)
    {
        var car = GameObject.Instantiate(carInstance);

        var characteristics = car.GetComponent<Characteristics>();
        characteristics.Set(3.0f, colors[Random.Range(0, colors.Count)], direction, fovValue);

        var fov = car.GetComponentsInChildren<BoxCollider>()[1];
        fov.center = new Vector3
            (direction.x * (fovValue / 2.0f),
            direction.y * (fovValue / 2.0f),
            fov.center.z);
        fov.size = new Vector3
            (direction.x == 0 ? fov.size.x : Mathf.Abs(direction.x) * fovValue,
            direction.y == 0 ? fov.size.y : Mathf.Abs(direction.y) * fovValue,
            fov.size.z);

        var spriteRenderer = car.GetComponent<SpriteRenderer>();
        spriteRenderer.color = characteristics.CarColor;

        return car;
    }
}
