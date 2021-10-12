using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Encapsulation of variables and methods
    private GameManager gameManager;
    private float speed = 40;
    private float topBound = 25;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        BoundScope();
    }

    void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
    }

    void BoundScope()
    {
        float bulletPosZ = transform.position.z;

        if (bulletPosZ > topBound)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fast Animal"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameManager.IncreaseScore(10);
        }

        else if (other.CompareTag("Animal"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameManager.IncreaseScore(5);
        }
    }
}
