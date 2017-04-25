using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Car
{
    public class Movement : MonoBehaviour
    {
        private float speed = 5.0f;

        private void Update()
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
}