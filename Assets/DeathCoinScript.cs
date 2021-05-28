using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCoinScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform player;
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        float x = Random.Range(-5, 5);
        float y = Random.Range(-5, 5);
        rb.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy")|| collision.gameObject.CompareTag("GravityCoin")|| collision.gameObject.CompareTag("GrowthCoin"))
        {
            collision.transform.gameObject.SetActive(false);
        }
        
    }
}
