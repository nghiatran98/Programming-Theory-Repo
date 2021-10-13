using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject SymbolicPowerUp;

    private GameManager gameManager;
    private Rigidbody playerRb;
    private float speed = 500;

    // Cooldown of shoot bullet
    private bool cooldown = false;
    private float normalCD = 0.5f;
    private float brustCD = 0.1f;
    private float shootCD;


    // Start is called before the first frame update
    void Start()
    {
        shootCD = normalCD;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        MovePlayer();
        ShootBullet();
    }

    // ABSTRACTION
    void MovePlayer()
    {
        // Make player move to right/ left
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    // ABSTRACTION
    private void ShootBullet()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (cooldown == false)
            {
                SpawnBullet();
                cooldown = true;
                Invoke("ResetCooldown", shootCD);
            }
        }
    }

    // ABSTRACTION
    private void SpawnBullet()
    {
        Vector3 bulletPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);

        Instantiate(bulletPrefab, bulletPos, bulletPrefab.transform.rotation);
    }

    // ABSTRACTION
    private void ResetCooldown()
    {
        cooldown = false;
    }

    private void ActivePowerUp()
    {
        SymbolicPowerUp.SetActive(true);
        shootCD = brustCD;
        StartCoroutine(DeactivePowerUp(15));
    }

    // ABSTRACTION
    IEnumerator DeactivePowerUp(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SymbolicPowerUp.SetActive(false);
        shootCD = normalCD;
    }

    // ABSTRACTION
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Power Up"))
        {
            ActivePowerUp();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fast Animal") || collision.gameObject.CompareTag("Animal"))
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }
    }

}
