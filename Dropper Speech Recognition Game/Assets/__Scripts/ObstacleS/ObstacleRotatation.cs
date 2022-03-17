using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotatation : MonoBehaviour
{
    // == Private Fields ==
    [SerializeField] private float rotation = 0.2f;

    void FixedUpdate()
    {
        // Rotate Obstacle
        gameObject.transform.Rotate(0, 0, rotation);
    }
} // Class - END
