using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 40;
    private float topBound = 25;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
