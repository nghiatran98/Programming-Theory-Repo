using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    private float speed = 20;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }

    // ABSTRACTION
    void MoveToPlayer()
    {
        if (player != null)
        {
            Vector3 distanceToPlayer = player.transform.position - transform.position;
            transform.Translate(distanceToPlayer.normalized * speed * Time.deltaTime, Space.World);
        }
       
        else
        {
            return;
        }
    }
}
