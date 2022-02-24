using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRemover : MonoBehaviour
{
    // == Private Fields ==
    private float position = -8f;
    void Update()
    {
        // If the obstacles crossed the position
        if (transform.position.y < position)
        {
            // Destroy the game object
            Destroy(gameObject);
        }
    }
}
