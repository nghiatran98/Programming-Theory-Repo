using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    // Encapsulation of variables and methods
    [SerializeField] protected float speed;
    protected Vector3 centerOfMass;
    protected Rigidbody animalRb;
    protected float bottomBound = -10;

    void FixedUpdate()
    {
        MoveForward();
        BoundScope();
    }

    protected virtual void MoveForward()
    {
        animalRb = GetComponent<Rigidbody>();
        animalRb.centerOfMass = centerOfMass;
        animalRb.AddRelativeForce(Vector3.forward * speed);
    }

    protected void BoundScope()
    {
        float animalPosZ = transform.position.z;

        if (animalPosZ < bottomBound)
        {
            Destroy(gameObject);
        }
    }

}
