using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class FastAnimal : Animal
{
    private float increaseSpeed = 1000;
    // POLYMORPHISM
    protected override void MoveForward()
    {
        speed += increaseSpeed;
        base.MoveForward();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveForward();
        BoundScope();
    }

    
}
