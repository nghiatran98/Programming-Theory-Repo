using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inherit class Animal
public class FastAnimal : Animal
{
    // Polymorphism MoveForward methods from parent class
    protected override void MoveForward()
    {
        speed = 10;
        base.MoveForward();
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        BoundScope();
    }
}
