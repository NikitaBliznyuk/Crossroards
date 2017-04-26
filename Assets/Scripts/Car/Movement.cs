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
        private Movement carInfront = null;
        private TrafficLightController lightController = null;

        public float CurrentSpeed { get { return currentSpeed; } }

        private void Start()
        {
            characteristics = GetComponent<Characteristics>();
            fieldOfView = GetComponent<BoxCollider>();

            currentSpeed = characteristics.MaxSpeed;
        }

        private void Update()
        {
            if ((lightController == null || lightController.IsGreen) && (carInfront == null || carInfront.CurrentSpeed > currentSpeed))
            {
                transform.Translate(characteristics.Direction * currentSpeed * Time.deltaTime);
            }
            else
            {

            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Traffic light"))
            {
                lightController = other.gameObject.GetComponent<TrafficLightController>();
            }
            else
            {
                carInfront = other.gameObject.GetComponent<Movement>();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Traffic light"))
            {
                lightController = null;
            }
            else
            {
                carInfront = null;
            }
        }
    }
}