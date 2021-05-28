using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragNShoot : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;

    public Vector2 minPower;
    public Vector2 maxPower;

    public LineRenderer lr;

    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    public GameObject enemyBall;
    public static bool canDestroyEnemy=false;

    public static int score;

    

    private void Start()
    {
        cam = Camera.main;
        score = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            RenderLine(startPoint, currentPoint);
        }
        if (Input.GetMouseButtonUp(0))
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);

            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y , minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);
            startPoint.z = 15;
            EndLine();
        }
        if (gameObject.transform.localScale.x < 0.05f)
        {
            SceneManager.LoadScene("RetryMenu");
        }
    }

    public void RenderLine(Vector3 startPoint, Vector3 endPoint)
    {
        lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startPoint;
        points[1] = endPoint;

        lr.SetPositions(points);
    }
    public void EndLine()
    {
        lr.positionCount = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.transform.localScale.x > 0.5f)
            {
                collision.transform.localScale = new Vector2(0.25f, 0.25f);
                gameObject.transform.localScale += new Vector3(0.03f, 0.03f, 0);
                score += 5;
            }
            else
            {
                collision.transform.gameObject.SetActive(false); 
                gameObject.transform.localScale += new Vector3(0.02f, 0.02f, 0);
                score += 10;
            }

        }
        else if (collision.gameObject.CompareTag("GravityCoin"))
        {
            StartCoroutine(GravityRoutine());
            collision.transform.gameObject.SetActive(false);
            score += 5;
        }
        else if (collision.gameObject.CompareTag("GrowthCoin"))
        {
            gameObject.transform.localScale += new Vector3(0.25f, 0.25f, 0);
            collision.transform.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("DeathCoin"))
        {
            gameObject.transform.localScale -= new Vector3(0.25f, 0.25f, 0);
            collision.transform.gameObject.SetActive(false);
            Spawner.deathCoinNumber--;
            score -= 5;
        }
        else if (collision.gameObject.CompareTag("StarCoin"))
        {
            gameObject.transform.localScale +=  new Vector3(0.05f, 0.05f, 0);
            score += 10;
        }
    }

    IEnumerator GravityRoutine()
    {
        EnemyBehav.currentGravity = -5;
        canDestroyEnemy = true;
        yield return new WaitForSeconds(3);
        EnemyBehav.currentGravity = 0;
        canDestroyEnemy = false;
    }
    
}
