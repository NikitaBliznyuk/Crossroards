using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Car
{
    public class Movement : MonoBehaviour
    {
        private float currentSpeed;
        private Characteristics characteristics;
        public Movement carInfront = null;
        public TrafficLightController lightController = null;

        public float CurrentSpeed { get { return currentSpeed; } }

        private void Start()
        {
            characteristics = GetComponent<Characteristics>();

            currentSpeed = characteristics.MaxSpeed;
        }

        private void Update()
        {
            Move();

            var distance = CalculateDistance();
            var stopSpeed = CalculateAcceleration(distance);
            stopSpeed = Mathf.Clamp(stopSpeed, 2.0f, stopSpeed);

            if ((lightController == null || lightController.IsGreen) && (carInfront == null || carInfront.CurrentSpeed > currentSpeed))
            {
                currentSpeed = Mathf.Lerp(currentSpeed, currentSpeed + characteristics.MaxSpeed, Time.deltaTime);
            }
            else if(distance >= 0.5f)
            {
                currentSpeed -= stopSpeed * Time.deltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, characteristics.MaxSpeed / 4.0f, characteristics.MaxSpeed);
            }
            else
            {
                currentSpeed = 0.0f;
            }
            currentSpeed = Mathf.Clamp(currentSpeed, 0.0f, characteristics.MaxSpeed);
        }

        private void Move()
        {
            transform.Translate(characteristics.Direction * currentSpeed * Time.deltaTime);
        }

        private float CalculateAcceleration(float distance)
        {
            return distance < 0.0f ? -1.0f : 2 * currentSpeed / distance;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Traffic light"))
            {
                lightController = other.gameObject.GetComponent<TrafficLightController>();
            }
            else if (other.CompareTag("Car") && carInfront == null)
            {
                if(Vector2.Angle(other.transform.position - transform.position, characteristics.Direction) == 0.0f)
                {
                    carInfront = other.gameObject.GetComponent<Movement>();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<TrafficLightController>() == lightController)
            {
                lightController = null;
            }
            else if (other.gameObject.GetComponent<Movement>() == carInfront)
            {
                carInfront = null;
            }
        }

        private float CalculateDistance()
        {
            var distanceToLight = 0.0f;
            var distanceToCar = 0.0f;

            if(lightController != null)
            {
                distanceToLight = (lightController.gameObject.transform.position - transform.position).magnitude;
            }
            if(carInfront != null)
            {
                distanceToCar = (carInfront.gameObject.transform.position - transform.position).magnitude;
            }
            
            if(lightController != null && carInfront != null)
            {
                return distanceToLight > distanceToCar ? distanceToCar : distanceToLight;
            }
            else if(lightController == null && carInfront != null)
            {
                return distanceToCar;
            }
            else if(carInfront == null && lightController != null)
            {
                return distanceToLight;
            }

            return 0.0f;
        }
    }
}