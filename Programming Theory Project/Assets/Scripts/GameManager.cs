using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    [SerializeField] public GameObject gameOver;

    [SerializeField] private GameObject[] enemyPrefabs;
    // Variables representing the coordinates of animal
    private float rangeX = 20;
    private float minPosZ = 30;
    private float maxPosZ = 40;
    private float posY = 2;

    // Variables representing the creation time of animal
    private float spawnStart = 1;
    private float spawnRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        gameObject.SetActive(false);
        InvokeRepeating("SpawnEnemy", spawnStart, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        if (isGameActive)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomIndex], RandomPosition(), enemyPrefabs[randomIndex].transform.rotation);
        }
    }

    Vector3 RandomPosition()
    {
        float randomXPos = Random.Range(-rangeX, rangeX);
        float randomZPos = Random.Range(minPosZ, maxPosZ);

        Vector3 randomPos = new Vector3(randomXPos, posY, randomZPos);

        return randomPos;
    }

    public void GameOver()
    {
        isGameActive = false;
        gameObject.SetActive(true);
    }

}
