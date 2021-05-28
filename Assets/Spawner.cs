using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform leftBot, rightTop;
    public GameObject enemyBall, gravityCoin,growthCoin,deathCoin,starCoin,goldCoin;
    bool canSpawnEnemy = true , canSpawnGravityCoin = true, canSpawnGrowthCoin = true , canSpawnDeathCoin = true , canSpawnStarCoin = true, canSpawnGoldCoin = true;
    public float delayTime = 1;
    public static float deathCoinNumber;

    void Start()
    {
        StartCoroutine(SpawnEnemy(0));
        deathCoinNumber = 0;
    }

    void Update()
    {
        if (canSpawnEnemy)
        {
            StartCoroutine(SpawnEnemy(delayTime));
        }
        if (canSpawnGravityCoin)
        {
            int x = Random.Range(10, 30);
            StartCoroutine(SpawnGravityCoin(x));
        }
        if (canSpawnGrowthCoin)
        {
            int y = Random.Range(10, 30);
            StartCoroutine(SpawnGrowthCoin(y));
        }
        if (canSpawnDeathCoin && deathCoinNumber <= 2)
        {
            int z = Random.Range(1,5);
            StartCoroutine(SpawnDeathCoin(z));
        }
        if (canSpawnStarCoin)
        {
            int z = Random.Range(50, 70);
            StartCoroutine(SpawnStarCoin(z));
        }
        if (canSpawnGoldCoin)
        {
            int t = Random.Range(30, 50);
            StartCoroutine(SpawnGoldCoin(t));
        }
    }
    IEnumerator SpawnEnemy(float delay)
    {
        canSpawnEnemy = false;
        yield return new WaitForSeconds(delay);
        float posX = Random.Range(leftBot.position.x, rightTop.position.x);
        float posY = Random.Range(leftBot.position.y, rightTop.position.y);
        Instantiate(enemyBall, new Vector2(posX, posY), Quaternion.identity);
        canSpawnEnemy = true;
    }
    IEnumerator SpawnGravityCoin(float delay)
    {
        canSpawnGravityCoin = false;
        yield return new WaitForSeconds(delay);
        float posX = Random.Range(leftBot.position.x, rightTop.position.x);
        float posY = Random.Range(leftBot.position.y, rightTop.position.y);
        Instantiate(gravityCoin, new Vector2(posX, posY), Quaternion.identity);
        canSpawnGravityCoin = true;
    }
    IEnumerator SpawnGrowthCoin(float delay)
    {
        canSpawnGrowthCoin = false;
        yield return new WaitForSeconds(delay);
        float posX = Random.Range(leftBot.position.x, rightTop.position.x);
        float posY = Random.Range(leftBot.position.y, rightTop.position.y);
        Instantiate(growthCoin, new Vector2(posX, posY), Quaternion.identity);
        canSpawnGrowthCoin = true;
    }
    IEnumerator SpawnDeathCoin(float delay)
    {
        canSpawnDeathCoin = false;
        deathCoinNumber++;
        yield return new WaitForSeconds(delay);
        float posX = Random.Range(leftBot.position.x, rightTop.position.x);
        float posY = Random.Range(leftBot.position.y, rightTop.position.y);
        Instantiate(deathCoin, new Vector2(posX, posY), Quaternion.identity);
        canSpawnDeathCoin = true;
    }
    IEnumerator SpawnStarCoin(float delay)
    {
        canSpawnStarCoin = false;
        yield return new WaitForSeconds(delay);
        Instantiate(starCoin, new Vector2(0,0), Quaternion.identity);
        canSpawnStarCoin = true;
    }
    IEnumerator SpawnGoldCoin(float delay)
    {
        canSpawnGoldCoin = false;
        yield return new WaitForSeconds(delay);
        float posX = Random.Range(leftBot.position.x, rightTop.position.x);
        float posY = Random.Range(leftBot.position.y, rightTop.position.y);
        Instantiate(goldCoin, new Vector2(posX, posY), Quaternion.identity);
        canSpawnGoldCoin = true;
    }
}
