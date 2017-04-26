using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creator
{
    protected GameObject carInstance;

    public Creator(GameObject carInstance)
    {
        this.carInstance = carInstance;
    }

    public abstract GameObject GetCar(Vector2 direction); 
}
