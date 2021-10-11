using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{

    public float speed = 2021;

    private Rigidbody animalRb;
    private Vector3 com;

    private float topBound = 50;
    private float bottomBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        animalRb = GetComponent<Rigidbody>();
        animalRb.centerOfMass = com;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveDown();
        BoundScope();
    }

    protected void MoveDown()
    {

        animalRb.AddRelativeForce(Vector3.forward * speed);
    }

    void BoundScope()
    {
        float animalPosZ = transform.position.z;

        if (animalPosZ < bottomBound)
        {
            Destroy(gameObject);
        }
    }

}
