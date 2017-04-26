using System.Collections.Generic;
using UnityEngine;
using Car;

public class BusCreator : Creator
{
    private List<Color> colors = new List<Color>();
    private float fovValue = 2.5f;
    private float offset = 0.16f;

    public BusCreator(GameObject carInstance) : base(carInstance)
    {
        colors.AddRange(new List<Color>() { Color.yellow, Color.blue, Color.white });
    }

    public override GameObject GetCar(Vector2 direction)
    {
        var car = GameObject.Instantiate(carInstance);

        var characteristics = car.GetComponent<Characteristics>();
        characteristics.Set(1.5f, colors[Random.Range(0, colors.Count)], direction, fovValue);

        var angle = direction.y != 0 ? 90 * (direction.y - 1) : 0.0f;
        angle -= 90 * direction.x;
        car.transform.Rotate(new Vector3(0, 0, angle));

        var fov = car.GetComponent<BoxCollider>();
        fov.center = new Vector3
            (fov.center.x,
            fovValue / 2.0f + offset,
            fov.center.z);
        fov.size = new Vector3
            (fov.size.x,
            fovValue,
            fov.size.z);

        var spriteRenderer = car.GetComponent<SpriteRenderer>();
        spriteRenderer.color = characteristics.CarColor;

        return car;
    }
}
