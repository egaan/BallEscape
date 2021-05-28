using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text gameScore;

    public void Update()
    {
        gameScore.text = ""+DragNShoot.score+"";
    }
}
