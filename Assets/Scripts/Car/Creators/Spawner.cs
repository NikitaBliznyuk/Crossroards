using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Range(0.5f, 2.0f)]
    public float flowDensity;
    public GameObject carPrefab;
    public GameObject taxiPrefab;
    public Vector2 direction;

    private float cooldown;
    private Creator[] creators;

    private float offset = 0.33f;

    private void Start()
    {
        creators = new Creator[] { new PassengerCarCreator(carPrefab), new TaxiCreator(taxiPrefab)};
        cooldown = flowDensity;
    }

    private void Update()
    {
        if(cooldown >= (3.5f - flowDensity))
        {
            var creatorIndex = Random.Range(0, creators.Length);
            var car = creators[creatorIndex].GetCar(direction);
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
