using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCoinScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.transform.localScale -= new Vector3(0.05f, 0.05f, 0);
        }
    }
    private void Update()
    {
        if (gameObject.transform.localScale.x < 0.05f)
        {
            gameObject.SetActive(false);
        }
    }
}
    