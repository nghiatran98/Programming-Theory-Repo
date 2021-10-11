using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private Rigidbody animalRb;
    public float speed = 500;
    // Start is called before the first frame update
    void Start()
    {
        animalRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDown();
    }

    protected void moveDown()
    {
        animalRb.AddForce(Vector3.forward * speed);
    }
}
