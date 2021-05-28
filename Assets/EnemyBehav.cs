using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehav : MonoBehaviour
{
    public float growingRate = 0.05f;
    public Rigidbody2D rb;

    public Renderer r;
    Color a = new Color(255, 100, 0, 255);
    Color b = new Color(255, 0, 0, 255);

    public static float currentGravity = 0;

    void Start()
    {
        r.GetComponent<Renderer>();
        rb.GetComponent<Rigidbody2D>();
        float x = Random.Range(-5, 5);
        float y = Random.Range(-5, 5);
        rb.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
    }

    
    void Update()
    {
        transform.localScale += new Vector3(growingRate, growingRate, 0) * Time.deltaTime;
        Color ab = r.material.color;
        ab.g -= Time.deltaTime * 0.025f;
        r.material.color = ab;

        rb.AddForce(new Vector2 (0, currentGravity));
    }
    
    
}
