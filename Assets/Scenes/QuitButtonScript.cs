using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Application.Quit();
    }
}
