using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    // Encapsulation of variables and methods
    protected float speed = 5;
    protected float bottomBound = -10;

    void Update()
    {
        MoveForward();
        BoundScope();
    }

    protected virtual void MoveForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
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
