using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Car
{
    public class Movement : MonoBehaviour
    {
        private float currentSpeed;
        private Characteristics characteristics;
        private BoxCollider fieldOfView;
        public Movement carInfront = null;
        public TrafficLightController lightController = null;
        private float stopSpeed = 0.0f;

        public float CurrentSpeed { get { return currentSpeed; } }

        private void Start()
        {
            characteristics = GetComponent<Characteristics>();
            fieldOfView = GetComponent<BoxCollider>();

            currentSpeed = characteristics.MaxSpeed;
        }

        private void Update()
        {
            Move();

            var distance = CalculateDistance();
            stopSpeed = CalculateAcceleration(distance);
            stopSpeed = stopSpeed < 0.5f ? 0.5f : stopSpeed;

            if ((lightController == null || lightController.IsGreen) && (carInfront == null || carInfront.CurrentSpeed > currentSpeed))
            {
                currentSpeed = characteristics.MaxSpeed;
            }
            else
            {
                if (currentSpeed > 0.0f)
                {
                    currentSpeed -= stopSpeed * Time.deltaTime;
                }
                else
                {
                    currentSpeed = 0.0f;
                }
            }
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
            if (other.CompareTag("Traffic light"))
            {
                lightController = null;
            }
            else if (other.CompareTag("Car"))
            {
                carInfront = null;
            }
        }

        private float CalculateDistance()
        {
            var distanceToLight = -1.0f;
            var distanceToCar = -1.0f;

            if(lightController != null)
            {
                distanceToLight = (lightController.transform.position - transform.position).magnitude;
            }
            if(carInfront != null)
            {
                distanceToCar = (carInfront.transform.position - transform.position).magnitude;
            }

            return distanceToLight > distanceToCar ? distanceToLight : distanceToCar;
        }
    }
}