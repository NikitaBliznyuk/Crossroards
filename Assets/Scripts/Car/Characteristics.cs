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
        private float fieldOfView;
        private Vector2 movementDirection;
        
        public Vector2 Direction { get { return movementDirection; } }
        public float MaxSpeed { get { return maxSpeed; } }
        public Color CarColor { get { return color; } }
        public float FieldOfView { get { return fieldOfView; } }
        public Vector2 RealDirection { get { return direction; } }

        public void Set(float maxSpeed, Color color, Vector2 direction, float fieldOfView)
        {
            this.maxSpeed = maxSpeed;
            this.color = color;
            this.direction = direction;
            this.fieldOfView = fieldOfView;
            movementDirection = direction;
        }
    }
}
