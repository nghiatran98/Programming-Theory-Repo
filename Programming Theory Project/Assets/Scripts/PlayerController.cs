using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Encapsulation of variables and methods
    [SerializeField] private GameObject bulletPrefab;
    private GameManager gameManager;
    private Rigidbody playerRb;
    private float speed = 500;

    // Cooldown of shoot bullet
    private bool cooldown = false;
    private float timeCoolDown = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        MovePlayer();
        ShootBullet();
    }

    void MovePlayer()
    {
        // Make player move to right/ left
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    void ShootBullet()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (cooldown == false)
            {
                SpawnBullet();
                cooldown = true;
                Invoke("ResetCooldown", timeCoolDown);
            }
        }
    }

    void SpawnBullet()
    {
        Vector3 bulletPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);

        Instantiate(bulletPrefab, bulletPos, bulletPrefab.transform.rotation);
    }

    void ResetCooldown()
    {
        cooldown = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fast Animal") || collision.gameObject.CompareTag("Slow Animal"))
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }
    }

}
