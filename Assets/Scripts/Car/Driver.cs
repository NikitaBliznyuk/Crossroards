using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Car;

public class Driver : MonoBehaviour
{
    private Movement car;
    public List<Movement> carsInfront = new List<Movement>();
    public TrafficLightController lightController = null;

    private void Start()
    {
        car = GetComponentInParent<Movement>();
    }

    private void Update()
    {
        int index;
        var distance = CalculateDistance(out index);
        var stopSpeed = CalculateAcceleration(distance);
        stopSpeed = Mathf.Clamp(stopSpeed, 2.0f, stopSpeed);

        if ((lightController == null || lightController.IsGreen) && (carsInfront.Count == 0 || carsInfront[index].CurrentSpeed > car.CurrentSpeed))
        {
            car.CurrentSpeed = Mathf.Lerp(car.CurrentSpeed, car.CurrentSpeed + car.CarCharacteristics.MaxSpeed, Time.deltaTime);
        }
        else if (distance >= 0.6f)
        {
            car.CurrentSpeed -= stopSpeed * Time.deltaTime;
            car.CurrentSpeed = Mathf.Clamp(car.CurrentSpeed, car.CarCharacteristics.MaxSpeed / 4.0f, car.CarCharacteristics.MaxSpeed);
        }
        else
        {
            car.CurrentSpeed = 0.0f;
        }
        car.CurrentSpeed = Mathf.Clamp(car.CurrentSpeed, 0.0f, car.CarCharacteristics.MaxSpeed);
    }

    private float CalculateDistance(out int index)
    {
        var distanceToLight = 0.0f;
        var distanceToCar = 0.0f;
        index = -1;

        if (lightController != null)
        {
            distanceToLight = (lightController.gameObject.transform.position - transform.position).magnitude;
        }

        if(carsInfront.Count > 0)
        {
            distanceToCar = (carsInfront[0].gameObject.transform.position - transform.position).magnitude;
            index = 0;
            for (int i = 1; i < carsInfront.Count; i++)
            {
                var newDIstance = (carsInfront[i].gameObject.transform.position - transform.position).magnitude;
                if(newDIstance < distanceToCar)
                {
                    index = i;
                    distanceToCar = newDIstance;
                }
            }
        }

        if (lightController != null && carsInfront.Count > 0)
        {
            return distanceToLight > distanceToCar ? distanceToCar : distanceToLight;
        }
        else if (carsInfront.Count == 0 && lightController != null)
        {
            return distanceToLight;
        }
        else if (lightController == null && carsInfront.Count > 0)
        {
            return distanceToCar;
        }

        return 0.0f;
    }

    private float CalculateAcceleration(float distance)
    {
        return distance < 0.0f ? -1.0f : 2 * car.CurrentSpeed / distance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Traffic light"))
        {
            lightController = other.gameObject.GetComponent<TrafficLightController>();
        }
        else if (other.CompareTag("Car"))
        {
            carsInfront.Add(other.gameObject.GetComponent<Movement>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (lightController != null && other.gameObject == lightController.gameObject)
        {
            lightController = null;
        }
        else if (carsInfront.Count > 0)
        {
            carsInfront.Remove(other.GetComponent<Movement>());
        }
    }
}
