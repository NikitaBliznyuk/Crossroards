using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Car
{
    public class Characteristics : MonoBehaviour
    {
        private float maxSpeed;
        private Color color;

        public float MaxSpeed { get { return maxSpeed; } }
        public Color CarColor { get { return color; } }

        public void  Set(float maxSpeed, Color color)
        {
            this.maxSpeed = maxSpeed;
            this.color = color;
        }
    }
}
