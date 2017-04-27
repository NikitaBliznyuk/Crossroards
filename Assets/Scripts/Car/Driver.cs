using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Car;

public class Driver : MonoBehaviour
{
    private Movement car;
    public Movement carInfront = null;
    public TrafficLightController lightController = null;

    private void Start()
    {
        car = GetComponentInParent<Movement>();
    }

    private void Update()
    {
        var distance = CalculateDistance();
        var stopSpeed = CalculateAcceleration(distance);
        stopSpeed = Mathf.Clamp(stopSpeed, 2.0f, stopSpeed);

        if ((lightController == null || lightController.IsGreen) && (carInfront == null || carInfront.CurrentSpeed > car.CurrentSpeed))
        {
            car.CurrentSpeed = Mathf.Lerp(car.CurrentSpeed, car.CurrentSpeed + car.CarCharacteristics.MaxSpeed, Time.deltaTime);
        }
        else if (distance >= 0.5f)
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

    private float CalculateDistance()
    {
        var distanceToLight = 0.0f;
        var distanceToCar = 0.0f;

        if (lightController != null)
        {
            distanceToLight = (lightController.gameObject.transform.position - transform.position).magnitude;
        }
        if (carInfront != null)
        {
            distanceToCar = (carInfront.gameObject.transform.position - transform.position).magnitude;
        }

        if (lightController != null && carInfront != null)
        {
            return distanceToLight > distanceToCar ? distanceToCar : distanceToLight;
        }
        else if (carInfront == null && lightController != null)
        {
            return distanceToLight;
        }
        else if (lightController == null && carInfront != null)
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
        Debug.Log(other.tag);
        if (other.CompareTag("Traffic light"))
        {
            lightController = other.gameObject.GetComponent<TrafficLightController>();
        }
        else if (other.CompareTag("Car") && carInfront == null)
        {
            carInfront = other.gameObject.GetComponent<Movement>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (lightController != null && other.gameObject == lightController.gameObject)
        {
            lightController = null;
        }
        else if (carInfront != null && other.gameObject == carInfront.gameObject)
        {
            carInfront = null;
        }
    }
}
