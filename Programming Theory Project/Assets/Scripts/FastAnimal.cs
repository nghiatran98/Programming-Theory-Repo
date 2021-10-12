using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class FastAnimal : Animal
{
    // POLYMORPHISM
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
