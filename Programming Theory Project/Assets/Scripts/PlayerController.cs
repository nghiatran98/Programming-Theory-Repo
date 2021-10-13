using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject SymbolicPowerUp;
    
    // Sounds & Effects variables
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip powerUpSound;
    [SerializeField] private AudioClip powerDownSound;
    [SerializeField] private AudioClip crashSound;
    private AudioSource playerAudio;
    private Animator playerAnim;

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
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
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
        playerAudio.PlayOneShot(shootSound, 1.0f);
    }

    // ABSTRACTION
    private void ResetCooldown()
    {
        cooldown = false;
    }

    // ABSTRACTION
    private void ActivePowerUp()
    {
        playerAudio.PlayOneShot(powerUpSound, 1.0f);
        SymbolicPowerUp.SetActive(true);
        shootCD = brustCD;
        StartCoroutine(DeactivePowerUp(15));
    }

    // ABSTRACTION
    IEnumerator DeactivePowerUp(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        playerAudio.PlayOneShot(powerDownSound, 1.0f);
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

    // ABSTRACTION

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fast Animal") || collision.gameObject.CompareTag("Animal"))
        {
            
            DestroyEffect();
            Destroy(collision.gameObject);
            gameManager.GameOver();
        }
    }

    // ABSTRACTION
    private void DestroyEffect()
    {
        playerRb.constraints = RigidbodyConstraints.FreezeAll;
        StartCoroutine(DeactivePowerUp(0));

        playerAudio.PlayOneShot(crashSound, 1.0f);
        explosionParticle.Play();
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int", 1);
    }
}
