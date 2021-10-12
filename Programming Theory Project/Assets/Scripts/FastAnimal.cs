using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class FastAnimal : Animal
{
    // POLYMORPHISM
    protected override void MoveForward()
    {
        base.MoveForward();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveForward();
        BoundScope();
    }

    
}
