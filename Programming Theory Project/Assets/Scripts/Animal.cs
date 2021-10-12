using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    protected float speed = 5;
    protected float bottomBound = -10;

    void Update()
    {
        MoveForward();
        BoundScope();
    }

    // ABSTRACTION
    protected virtual void MoveForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // ABSTRACTION
    protected void BoundScope()
    {
        float animalPosZ = transform.position.z;

        if (animalPosZ < bottomBound)
        {
            Destroy(gameObject);
        }
    }

}
