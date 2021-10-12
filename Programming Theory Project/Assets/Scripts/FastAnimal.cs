using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inherit class Animal
public class FastAnimal : Animal
{
    // Polymorphism MoveForward methods from parent class
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
