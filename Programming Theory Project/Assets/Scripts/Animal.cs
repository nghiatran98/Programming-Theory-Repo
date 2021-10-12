using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private GameManager gameManager;
    public float speed = 2021;

    private Rigidbody animalRb;
    private Vector3 com;

    private float bottomBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            gameManager.GameOver();
        }
    }

}
