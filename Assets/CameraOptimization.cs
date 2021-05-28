using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOptimization : MonoBehaviour
{
    public SpriteRenderer rink;

    
    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        Debug.Log(Screen.width);
        float targetRatio = rink.bounds.size.x / rink.bounds.size.y;

        if (screenRatio >= targetRatio)
        {
            
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            
        }
    }

}
