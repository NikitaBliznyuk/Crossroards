using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Car
{
    public class Characteristics : MonoBehaviour
    {
        private float maxSpeed;
        private Color color;
        private Vector2 direction;
        
        public Vector2 Direction { get { return direction; } }
        public float MaxSpeed { get { return maxSpeed; } }
        public Color CarColor { get { return color; } }

        public void Set(float maxSpeed, Color color, Vector2 direction)
        {
            this.maxSpeed = maxSpeed;
            this.color = color;
            this.direction = direction;
        }
    }
}
