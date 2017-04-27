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
        }

        private void Move()
        {
            transform.Translate(characteristics.Direction * CurrentSpeed * Time.deltaTime);
        }
    }
}