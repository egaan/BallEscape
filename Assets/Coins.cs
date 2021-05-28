using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public Rigidbody2D rb;
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        float x = Random.Range(-5, 5);
        float y = Random.Range(-5, 5);
        rb.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
    }
}
