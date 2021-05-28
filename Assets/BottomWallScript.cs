using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomWallScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && DragNShoot.canDestroyEnemy)
        {
            collision.transform.gameObject.SetActive(false);
        }
    }
}
