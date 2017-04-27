using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Car
{
    public class Movement : MonoBehaviour
    {
        private Characteristics characteristics;

        public Characteristics CarCharacteristics { get { return characteristics; } }
        public float CurrentSpeed { get; set; }

        private void Start()
        {
            characteristics = GetComponent<Characteristics>();

            CurrentSpeed = characteristics.MaxSpeed;
        }

        private void Update()
        {
            Move();

            //var distance = CalculateDistance();
            //var stopSpeed = CalculateAcceleration(distance);
            //stopSpeed = Mathf.Clamp(stopSpeed, 2.0f, stopSpeed);

            //if ((lightController == null || lightController.IsGreen) && (carInfront == null || carInfront.CurrentSpeed > currentSpeed))
            //{
            //    currentSpeed = Mathf.Lerp(currentSpeed, currentSpeed + characteristics.MaxSpeed, Time.deltaTime);
            //}
            //else if (distance >= 0.5f)
            //{
            //    currentSpeed -= stopSpeed * Time.deltaTime;
            //    currentSpeed = Mathf.Clamp(currentSpeed, characteristics.MaxSpeed / 4.0f, characteristics.MaxSpeed);
            //}
            //else
            //{
            //    currentSpeed = 0.0f;
            //}
            //currentSpeed = Mathf.Clamp(currentSpeed, 0.0f, characteristics.MaxSpeed);
        }

        private void Move()
        {
            transform.Translate(characteristics.Direction * CurrentSpeed * Time.deltaTime);
        }

    }
}