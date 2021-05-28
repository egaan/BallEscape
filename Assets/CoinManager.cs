using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject player;
    public Transform collectableTransform;
    public static CoinManager CM;
    public Coins coins;
    public enum Coins
    {
        growthCoin,
        deathCoin,
        gravityCoin,
        food,
        none
    }
    void Start()
    {
        coins = Coins.none;
        CM = GetComponent<CoinManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (coins)
        {
            case Coins.growthCoin:
                player.transform.localScale += new Vector3(0.25f, 0.25f, 0);
                coins = Coins.none;
                break;
            case Coins.deathCoin:
                player.transform.localScale -= new Vector3(0.25f, 0.25f, 0);
                coins = Coins.none;
                break;
            case Coins.gravityCoin:
                StartCoroutine(GravityRoutine(3));
                break;
            case Coins.food:
                //if(collectableTransform<player.transform)
                break;
            case Coins.none:
                break;
        }
    }
    IEnumerator GravityRoutine(float delay)
    {
        EnemyBehav.currentGravity = -5;
        yield return new WaitForSeconds(delay);
        EnemyBehav.currentGravity = 0;
    }
}
