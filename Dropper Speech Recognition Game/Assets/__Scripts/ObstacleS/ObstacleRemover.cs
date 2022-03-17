using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRemover : MonoBehaviour
{
    // == Private Fields ==
    private float position = -7.6f;

    void Update()
    {
        // If the obstacles crossed the position
        if (transform.position.y < position)
        {
            // Destroy the game object
            Destroy(gameObject);

            // Update Score when obstacle is destroyed
            GameData.UpdateScore(1);
        }
    }
} // Class - END
