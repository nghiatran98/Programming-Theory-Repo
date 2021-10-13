using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ENCAPSULATION
    public float score { get; private set; }

    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject powerUpPrefab;
    [SerializeField] private GameObject symbolicPowerUp;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] enemyPrefabs;
    
    private bool isGameActive;
    private string playerName;
    // Variables representing the coordinates of animal
    private float rangeX = 20;
    private float minPosZ = 30;
    private float maxPosZ = 40;
    private float posY = 2;
    // Variables representing the creation time of animal
    private float spawnRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        playerName = MainManager.Instance.playerName;
        isGameActive = true;
        Invoke("SpawnEnemy", spawnRate);
    }

    private void LateUpdate()
    {
        MoveSymbolicPowerUp();
    }

    // ABSTRACTION
    private void SpawnEnemy()
    {
        if (isGameActive)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomIndex], RandomPosition(), enemyPrefabs[randomIndex].transform.rotation);
            Invoke("SpawnEnemy", spawnRate);
        }
    }

    // ABSTRACTION
    private Vector3 RandomPosition()
    {
        float randomXPos = Random.Range(-rangeX, rangeX);
        float randomZPos = Random.Range(minPosZ, maxPosZ);

        Vector3 randomPos = new Vector3(randomXPos, posY, randomZPos);

        return randomPos;
    }

    // ABSTRACTION
    private void MoveSymbolicPowerUp()
    {
        if (player != null)
        {
            Vector3 symbolicPos = new Vector3(player.transform.position.x, player.transform.position.y + 2.5f, player.transform.position.z + 0.5f) ;
            symbolicPowerUp.transform.position = symbolicPos;
        }

        else
        {
            return;
        }
        
    }

    // ABSTRACTION
    public void GameOver()
    {
        isGameActive = false;
        MainManager.Instance.SaveHighScore(playerName, score);
        gameOver.SetActive(true);
    }

    // ABSTRACTION
    public void IncreaseScore(float addScore)
    {
        score += addScore;
    }

    // ABSTRACTION
    public void SpawnPowerUp(Vector3 powerUpPos)
    {
        float dropRate = 50;
        float rateNumber = RandomRateNumber();

        // 50% drop item Power Up
        if (rateNumber >= dropRate)
        {
            Instantiate(powerUpPrefab, powerUpPos, powerUpPrefab.transform.rotation);
        }

        else
        {
            return;
        }
        
    }

    // ABSTRACTION
     float RandomRateNumber()
    {
        float randomRateNumber = Random.Range(1, 100);
        return randomRateNumber;
    }

}
