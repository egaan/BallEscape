using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private CoinManager.Coins _coin;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("playerboş");
        DragNShoot _player = other.gameObject.GetComponent<DragNShoot>();
        if (_player != null)
        {
            CoinManager.CM.collectableTransform = transform;
            CoinManager.CM.coins = _coin;
            StartCoroutine(Destroy(0));
        }
    }
    private IEnumerator Destroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.gameObject.SetActive(false);
    }
}
