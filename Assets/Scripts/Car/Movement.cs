using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Car
{
    public class Movement : MonoBehaviour
    {
        private float speed = 5.0f;
        private Characteristics characteristics;

        private void Start()
        {
            characteristics.GetComponent<Characteristics>();
        }

        private void Update()
        {
            transform.Translate(characteristics.Direction * speed * Time.deltaTime);
        }
    }
}